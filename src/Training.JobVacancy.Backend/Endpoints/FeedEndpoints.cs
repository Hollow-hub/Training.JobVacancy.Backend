namespace Adaptit.Training.JobVacancy.Backend.Endpoints;

using Adaptit.Training.JobVacancy.Backend.Data;
using Adaptit.Training.JobVacancy.Backend.Dto;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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

  public static async Task<Results<NotFound, Ok<Feed>>> GetFirstPage([FromQuery(Name = "last")] string last)
  {
    var feed = DataCreatorFeed.FeedFaker.Generate();

    if (feed == null)
    {
      return TypedResults.NotFound();
    }

    return TypedResults.Ok(feed);
  }


  public static async Task<Results<NotFound, Ok<Feed>>> GetSpecifiedPage(int feedPageId)
  {
    var feed = DataCreatorFeed.FeedFaker.Generate();

    if (feed == null)
    {
      return TypedResults.NotFound();
    }

    return TypedResults.Ok(feed);
  }
}
