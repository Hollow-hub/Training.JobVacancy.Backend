namespace Adaptit.Training.JobVacancy.Backend;

using Adaptit.Training.JobVacancy.Backend.Dto;

using Refit;

public interface IPamStillingFeed
{
  [Get("/api/v1/feed")]
  Task<ApiResponse<Feed>> GetFirstPage([AliasAs("last")] string last);

  [Get("/api/v1/feed/{feedPageId}")]
  Task<ApiResponse<Feed>> GetSpecifiedPage(int feedPageId);

  [Get("/api/v1/feedentry/{entryId}")]
  Task<ApiResponse<FeedEntry>> GetSpecifiedFeedEntry(int entryId);
}
