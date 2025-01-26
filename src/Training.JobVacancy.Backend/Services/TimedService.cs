namespace Adaptit.Training.JobVacancy.Backend.Services;

using Adaptit.Training.JobVacancy.Backend.Dto;

public class TimedService(IPamStillingFeed pamStillingFeed) : BackgroundService
{
  private readonly IPamStillingFeed pamStillingFeed = pamStillingFeed;
  private readonly Dictionary<string, Feed> feeds = new();
  private readonly Dictionary<string, FeedEntry> feedEntries = new();
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
      }
    }
  }

  public void Trigger() => cts?.Cancel();

  private async Task DoWork(CancellationToken token)
  {
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
