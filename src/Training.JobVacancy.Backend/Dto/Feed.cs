namespace Adaptit.Training.JobVacancy.Backend.Dto;

using System.Text.Json.Serialization;

public class Feed
{
  public required string Version { get; set; }
  public required string Title { get; set; }

  [JsonPropertyName("home_page_url")]
  public required string HomePageUrl { get; set; }

  [JsonPropertyName("feed_url")]
  public required string FeedUrl { get; set; }

  public required string Description { get; set; }

  [JsonPropertyName("next_url")]
  public string? NextUrl { get; set; }

  public required string Id { get; set; }

  [JsonPropertyName("next_id")]
  public string? NextId { get; set; }

  public required Items[] Items { get; set; }
}

public class Items
{
  public required string Id { get; set; }
  public required string Url { get; set; }
  public required string Title { get; set; }

  [JsonPropertyName("content_text")]
  public required string ContentText { get; set; }

  [JsonPropertyName("date_modified")]
  public string? DateModified { get; set; }

  [JsonPropertyName("_feed_entry")]
  public required feedEntry FeedEntry { get; set; }
}

public class feedEntry
{
  public required string Uuid { get; set; }
  public required string Status { get; set; }
  public required string Title { get; set; }
  public required string BusinessName { get; set; }
  public required string Municipal { get; set; }
  public required string SistEndret { get; set; }
}
