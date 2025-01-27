namespace Adaptit.Training.JobVacancy.Persistence.Model;

public class Feed
{
  public Guid Id { get; set; }
  public string Version { get; set; }
  public string Title { get; set; }
  public Uri HomePageUrl { get; set; }
  public string Description { get; set; }
  public Feed? Next { get; set; }
  public ICollection<Item> Items { get; set; } = [];
}

public class Item
{
  public Guid Id { get; set; }

  public string Title { get; set; }

  public string ContentText { get; set; }
  public DateTime? DateModified { get; set; }

  public feedEntry FeedEntry { get; set; }
  public Feed Feed { get; set; }
}

public class feedEntry
{
  public Guid Uuid { get; set; }
  public string Status { get; set; }
  public string Title { get; set; }
  public string BusinessName { get; set; }
  public string Municipal { get; set; }
  public DateTime SistEndret { get; set; }
}
