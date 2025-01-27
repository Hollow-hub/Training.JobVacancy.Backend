namespace Adaptit.Training.JobVacancy.Backend.Dto;

using System.Text.Json.Serialization;

public class FeedDto
{
  public string Version { get; set; }
  public string Title { get; set; }

  [JsonPropertyName("home_page_url")]
  public Uri HomePageUrl { get; set; }

  [JsonPropertyName("feed_url")]
  public string FeedUrl { get; set; }

  public string Description { get; set; }

  [JsonPropertyName("next_url")]
  public string? NextUrl { get; set; }

  public Guid Id { get; set; }

  [JsonPropertyName("next_id")]
  public string? NextId { get; set; }

  public ItemDto[] Items { get; set; }
}

public class ItemDto
{
  public Guid Id { get; set; }
  public string Url { get; set; }
  public string Title { get; set; }

  [JsonPropertyName("content_text")]
  public string ContentText { get; set; }

  [JsonPropertyName("date_modified")]
  public DateTime? DateModified { get; set; }

  [JsonPropertyName("_feed_entry")]
  public feedEntry FeedEntry { get; set; }
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
