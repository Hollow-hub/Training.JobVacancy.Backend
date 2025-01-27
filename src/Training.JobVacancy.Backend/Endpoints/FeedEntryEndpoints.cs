namespace Adaptit.Training.JobVacancy.Backend.Endpoints;

using Adaptit.Training.JobVacancy.Backend.Data;
using Adaptit.Training.JobVacancy.Backend.Dto;

using Microsoft.AspNetCore.Http.HttpResults;

public static class FeedEntryEndpoints
{
  public static IEndpointRouteBuilder MapFeedEntryEndpoints(this IEndpointRouteBuilder endpoints)
  {
    endpoints.MapGet("api/v1/feedentry/{entryId:int}", GetSpecifiedFeedEntry).WithOpenApi();

    return endpoints;
  }

  public static async Task<Results<NotFound, Ok<FeedEntryDto>>> GetSpecifiedFeedEntry(int entryId)
  {
    var feedEntry = DataCreatorFeed.GetFeedEntry();

    if (feedEntry == null)
    {
      return TypedResults.NotFound();
    }

    return TypedResults.Ok(feedEntry);
  }
}
