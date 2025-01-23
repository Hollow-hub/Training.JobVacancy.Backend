namespace Adaptit.Training.JobVacancy.Backend.Dto
{
    public class Feed
    {
      public required string version { get; set; }
      public required string title { get; set; }
      public required string home_page_url { get; set; }
      public required string feed_url { get; set; }
      public required string description { get; set; }
      public string? next_url { get; set; }
      public required string id { get; set; }
      public string? next_id { get; set; }
      public required Items[] items { get; set; }
    }

    public class Items
    {
      public required string id { get; set; }
      public required string url { get; set; }
      public required string title { get; set; }
      public required string content_text { get; set; }
      public string? date_modified { get; set; }
      public required _feed_entry _feed_entry { get; set; }
    }

    public class _feed_entry
    {
      public required string uuid { get; set; }
      public required string status { get; set; }
      public required string title { get; set; }
      public required string businessName { get; set; }
      public required string municipal { get; set; }
      public required string sistEndret { get; set; }
    }
}
