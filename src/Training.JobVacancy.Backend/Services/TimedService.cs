namespace Adaptit.Training.JobVacancy.Backend.Services;

using Adaptit.Training.JobVacancy.Backend.Dto;

public class TimedService : BackgroundService
{
  private readonly IPamStillingFeed pamStillingFeed;
  private readonly Dictionary<string, Feed> feeds = new();
  private readonly Dictionary<string, FeedEntry> feedEntries = new();
  private CancellationTokenSource? cts;

  public TimedService(IPamStillingFeed pamStillingFeed) => this.pamStillingFeed = pamStillingFeed;

  /// <inheritdoc />
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    cts = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);

    while (!stoppingToken.IsCancellationRequested)
    {
      try
      {
        var firstPageResponse = await pamStillingFeed.GetFirstPage(null);
        if (firstPageResponse is { IsSuccessStatusCode: true, Content: not null })
        {
          await ProcessFeed(firstPageResponse.Content, cts.Token);
        }

        await Task.Delay(TimeSpan.FromMinutes(30), cts.Token);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
  }

  private async Task ProcessFeed(Feed feed, CancellationToken stoppingToken)
  {
    while (feed != null && !stoppingToken.IsCancellationRequested)
    {
      foreach (var item in feed.Items)
      {
        var feedEntry = item.FeedEntry;

        //feedEntries.AddOrUpdate(feedEntry.Uuid, feedEntry, (key, existing) => feedEntry);
      }

      if (string.IsNullOrEmpty(feed.NextId))
      {
        continue;
      }

      var nextPageResponse = await pamStillingFeed.GetSpecifiedPage(int.Parse(feed.NextId));
      if (nextPageResponse is { IsSuccessStatusCode: true, Content: not null })
      {
        feed = nextPageResponse.Content;
      }
    }
  }

  public override void Dispose()
  {
    cts?.Cancel();
    cts?.Dispose();
    base.Dispose();
  }

  public FeedEntry? GetFeedEntryById(string uuid)
  {
    feedEntries.TryGetValue(uuid, out var feedEntry);
    return feedEntry;
  }
}
