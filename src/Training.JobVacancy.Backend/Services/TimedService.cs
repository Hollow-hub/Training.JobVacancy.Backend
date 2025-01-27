namespace Adaptit.Training.JobVacancy.Backend.Services;

using Adaptit.Training.JobVacancy.Persistence;
using Adaptit.Training.JobVacancy.Persistence.Model;

public class TimedService(IPamStillingFeed pamStillingFeed, JobVacancyDbContext dbContext, ILogger<TimedService> logger) : BackgroundService
{
  private readonly IPamStillingFeed pamStillingFeed = pamStillingFeed;
  private readonly JobVacancyDbContext dbContext = dbContext;
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
    try
    {
      var firstPage = await pamStillingFeed.GetFirstPage(null);
      if (firstPage.IsSuccessful)
      {
        var feed = firstPage.Content;
        //await SaveFeedDataToDb(feed);

        foreach (var item in feed.Items)
        {
          //await SaveFeedEntryDataToDb(item.FeedEntry);
        }
      }
    }
    catch (Exception e)
    {
      logger.LogCritical(e, "An error occurred while fetching the feed.");
    }
  }

  private async Task SaveFeedDataToDb(Feed feed)
  {
    var dbFeed = new Feed
    {
      Version = feed.Version,
      Title = feed.Title,
      HomePageUrl = feed.HomePageUrl,
      FeedUrl = feed.FeedUrl,
      Description = feed.Description,
      NextUrl = feed.NextUrl,
      Id = feed.Id,
      NextId = feed.NextId
    };

    dbContext.Feeds.Add(dbFeed);
    await dbContext.SaveChangesAsync();
  }

  private async Task SaveFeedEntryDataToDb(feedEntry feedEntry)
  {
    var dbfeedEntry = new feedEntry
    {
      Uuid = feedEntry.Uuid,
      Status = feedEntry.Status,
      Title = feedEntry.Title,
      BusinessName = feedEntry.BusinessName,
      Municipal = feedEntry.Municipal,
      SistEndret = feedEntry.SistEndret
    };

    dbContext.feedEntries.Add(dbfeedEntry);
    await dbContext.SaveChangesAsync();
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
