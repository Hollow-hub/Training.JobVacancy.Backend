namespace Adaptit.Training.JobVacancy.Backend.Endpoints;

using Adaptit.Training.JobVacancy.Backend.Data;
using Adaptit.Training.JobVacancy.Backend.Dto;

using Microsoft.AspNetCore.Http.HttpResults;

public static class FeedEndpoints
{
  public static IEndpointRouteBuilder MapFeedEndpoints(this IEndpointRouteBuilder endpoints)
  {
    var api = endpoints.MapGroup("/api/v1/feed")
      .WithOpenApi();

    api.MapGet("", GetFirstPage);
    api.MapGet("/{feedPageId:int}", GetSpecifiedPage);

    return endpoints;
  }

  public static async Task<Results<NotFound, Ok<Feed>>> GetFirstPage()
  {
    var feed = DataCreatorFeed.GetFeed();

    if (feed == null)
    {
      return TypedResults.NotFound();
    }

    return TypedResults.Ok(feed);
  }


  public static async Task<Results<NotFound, Ok<Feed>>> GetSpecifiedPage(int id)
  {
    var feed = DataCreatorFeed.GetFeed();

    if (feed == null)
    {
      return TypedResults.NotFound();
    }

    return TypedResults.Ok(feed);
  }
}
