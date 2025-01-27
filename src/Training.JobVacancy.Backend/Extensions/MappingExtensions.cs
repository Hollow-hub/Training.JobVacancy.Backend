namespace Adaptit.Training.JobVacancy.Backend.Extensions;

using Adaptit.Training.JobVacancy.Backend.Dto;
using Adaptit.Training.JobVacancy.Persistence.Model;

public static class MappingExtensions
{
  public static Feed ToEntity(this FeedDto dto)
  {
    var feed = new Feed()
    {
      Id = dto.Id,
      Title = dto.Title,
      HomePageUrl = dto.HomePageUrl,
      Description = dto.Description,
      Version = dto.Version,
      Next = null,
    };
    feed.Items = dto.Items.Select(x => x.ToEntity(feed)).ToList();
    return feed;
  }

  public static Item ToEntity(this ItemDto dto, Feed feed)
  {
    return new Item()
    {
      Id = dto.Id,
      Title = dto.Title,
      ContentText = dto.ContentText,
      DateModified = dto.DateModified?.ToUniversalTime(),
      Feed = feed,
    };
  }
}
