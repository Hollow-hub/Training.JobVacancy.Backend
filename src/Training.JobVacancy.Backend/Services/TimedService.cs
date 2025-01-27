namespace Adaptit.Training.JobVacancy.Backend.Services;

using System.Globalization;

using Adaptit.Training.JobVacancy.Backend.Extensions;
using Adaptit.Training.JobVacancy.Persistence;

public class TimedService(
  IPamStillingFeed pamStillingFeed,
  IServiceScopeFactory scopeFactory,
  ILogger<TimedService> logger) : BackgroundService
{
  private readonly IServiceScopeFactory scopeFactory = scopeFactory;
  private const int MaxDepth = 15;
  private readonly IPamStillingFeed pamStillingFeed = pamStillingFeed;
  private CancellationTokenSource? cts;

  /// <inheritdoc />
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await Task.Delay(TimeSpan.Zero, stoppingToken);
    while (!stoppingToken.IsCancellationRequested)
    {
      try
      {
        RefreshToken(stoppingToken);
        await Task.Delay(TimeSpan.FromMinutes(30), cts!.Token);
      }
      catch (OperationCanceledException)
      {
      }

      try
      {
        await DoWork(stoppingToken);
      }
      catch (OperationCanceledException)
      {
      }
      catch (Exception ex)
      {
        logger.LogCritical(ex, "An error occurred while processing the feed.");
      }
    }
  }

  public void Trigger() => cts?.Cancel();

  private async Task DoWork(CancellationToken token)
  {
    await using var scope = scopeFactory.CreateAsyncScope();
    var db = scope.ServiceProvider.GetRequiredService<JobVacancyDbContext>();

    var firstPage = await pamStillingFeed.GetFirstPage(
      DateTime.Now.AddDays(-1).ToString(CultureInfo.InvariantCulture.DateTimeFormat.RFC1123Pattern));
    if (!firstPage.IsSuccessful || firstPage.Content == null)
    {
      return;
    }

    var feed = firstPage.Content;

    db.Feeds.Add(feed.ToEntity());
    await db.SaveChangesAsync(token);
  }

  private void RefreshToken(CancellationToken stoppingToken)
  {
    if (cts is { Token.IsCancellationRequested: false })
    {
      return;
    }

    cts?.Cancel();
    cts?.Dispose();
    cts = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
  }

  public override void Dispose()
  {
    cts?.Cancel();
    cts?.Dispose();
    base.Dispose();
  }
}
