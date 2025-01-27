namespace Adaptit.Training.JobVacancy.Backend;

using Adaptit.Training.JobVacancy.Backend.Dto;

using Refit;

[Headers("Authorization: Bearer")]
public interface IPamStillingFeed
{
  [Get("/api/v1/feed")]
  Task<ApiResponse<FeedDto>> GetFirstPage([Header("If-Modified-Since")]string modifiedAfter, [AliasAs("last")] string? last = null);

  [Get("/api/v1/feed/{feedPageId}")]
  Task<ApiResponse<FeedDto>> GetSpecifiedPage(Guid feedPageId);

  [Get("/api/v1/feedentry/{entryId}")]
  Task<ApiResponse<FeedEntryDto>> GetSpecifiedFeedEntry(int entryId);
}
