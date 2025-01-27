namespace Adaptit.Training.JobVacancy.Persistence.Model;

public class Feed
{
  public required string Id { get; set; }

  public string Version { get; set; }

  public string Title { get; set; }

  public string HomePageUrl { get; set; }

  public string FeedUrl { get; set; }

  public string Description { get; set; }

  public string? NextUrl { get; set; }

  public string? NextId { get; set; }

  public ICollection<Item> Items { get; set; } = [];
}

public class Item
{
  public string Id { get; set; }

  public string Url { get; set; }

  public string Title { get; set; }

  public string ContentText { get; set; }

  public string? DateModified { get; set; }

  public FeedEntry FeedEntry { get; set; }


  public string FeedId { get; set; }

  public Feed Feed { get; set; }
}

public class feedEntry
{
  public string Uuid { get; set; }

  public string Status { get; set; }

  public string Title { get; set; }

  public string BusinessName { get; set; }

  public string Municipal { get; set; }

  public string SistEndret { get; set; }
}
