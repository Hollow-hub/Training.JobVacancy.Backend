namespace Adaptit.Training.JobVacancy.Backend.Data;

using System.Globalization;

using Adaptit.Training.JobVacancy.Backend.Dto;

using Bogus;

public static class DataCreatorFeed
{
  public static Faker<FeedDto> FeedFaker { get; } = new Faker<FeedDto>()
    .RuleFor(q => q.Version, f => f.Random.Int(1,10).ToString())
    .RuleFor(q => q.Title, q => q.WaffleTitle())
    .RuleFor(q => q.HomePageUrl, f => new Uri(f.Internet.Url()))
    .RuleFor(q => q.FeedUrl, f => f.Internet.Url().ToString())
    .RuleFor(q => q.Description, q => q.WaffleText())
    .RuleFor(q => q.NextUrl, f => f.Internet.Url().ToString())
    .RuleFor(q => q.Id, q => q.Random.Guid())
    .RuleFor(q => q.NextId, q => q.Random.Int(1, 100).ToString())
    .RuleFor(q => q.Items, q => [.. ItemsFaker.Generate(q.Random.Int(1, 3))]);

  public static Faker<ItemDto> ItemsFaker { get; } = new Faker<ItemDto>()
    .RuleFor(q => q.Id, f => f.Random.Guid())
    .RuleFor(q => q.Url, f => f.Internet.Url().ToString())
    .RuleFor(q => q.Title, q => q.WaffleText())
    .RuleFor(q => q.ContentText, q => q.WaffleText())
    .RuleFor(q => q.DateModified, f => f.Date.Past().ToUniversalTime())
    .RuleFor(q => q.FeedEntry, f => FeedEntryFaker.Generate());

  public static Faker<feedEntry> FeedEntryFaker { get; } = new Faker<feedEntry>()
    .RuleFor(q => q.Uuid, q => q.Random.Guid().ToString())
    .RuleFor(q => q.Status, f => "Active")
    .RuleFor(q => q.Title, f => f.Company.Bs())
    .RuleFor(q => q.BusinessName, f => f.Company.CompanyName())
    .RuleFor(q => q.Municipal, f => f.Random.Words())
    .RuleFor(q => q.SistEndret, f => f.Date.Past().ToString(CultureInfo.InvariantCulture));

  public static FeedEntryDto GetFeedEntry()
  {
    var feedEntry = new Faker<FeedEntryDto>()
      .RuleFor(q => q.Uuid, q => q.Random.Guid().ToString())
      .RuleFor(q => q.SistEndret, f => f.Date.Past().ToString(CultureInfo.InvariantCulture))
      .RuleFor(q => q.Status, f => "Active")
      .RuleFor(q => q.AdContent,
        f => new AdContent
        {
          Uuid = f.Random.Guid().ToString(),
          Published = f.Date.Past().ToString(CultureInfo.InvariantCulture),
          Expires = f.Date.Future().ToString(CultureInfo.InvariantCulture),
          Updated = f.Date.Future().ToString(CultureInfo.InvariantCulture),
          WorkLocations =
          [
            new WorkLocations
            {
              Country = f.Address.Country().ToString(),
              Address = f.Address.StreetAddress().ToString(),
              City = f.Address.City().ToString(),
              PostalCode = f.Address.ZipCode().ToString(),
              County = f.Address.County().ToString(),
              Municipal = f.Address.City().ToString()
            }
          ],
          ContactList =
          [
            new ContactList
            {
              Name = f.Name.FullName().ToString(),
              Email = f.Internet.Email().ToString(),
              Phone = f.Phone.PhoneNumber().ToString(),
              Role = f.Random.Words().ToString(),
              Title = f.Random.Words().ToString()
            }
          ],
          Title = f.Random.Words().ToString(),
          Description = f.Random.Words().ToString(),
          Sourceurl = f.Internet.Url().ToString(),
          Source = f.Random.Words().ToString(),
          ApplicationUrl = f.Internet.Url().ToString(),
          ApplicationDue = f.Date.Future().ToString(CultureInfo.InvariantCulture),
          OccupationCategories =
          [
            new OccupationCategories { Level1 = f.Random.Words().ToString(), Level2 = f.Random.Words().ToString() }
          ],
          CategoryList =
          [
            new CategoryList
            {
              CategoryType = f.Random.Words().ToString(),
              Code = f.Random.Words().ToString(),
              Name = f.Random.Words().ToString(),
              Description = f.Random.Words().ToString(),
              Score = f.Random.Int(1, 100)
            }
          ],
          Jobtitle = f.Random.Words().ToString(),
          Link = f.Internet.Url().ToString(),
          Employer = new Employer
          {
            Name = f.Company.CompanyName().ToString(),
            Orgnr = f.Random.Int(100000, 999999).ToString(),
            Description = f.Random.Words().ToString(),
            Homepage = f.Internet.Url().ToString()
          },
          Engagementtype = f.Random.Words().ToString(),
          Extent = f.Random.Words().ToString(),
          Starttime = f.Date.Future().ToString(CultureInfo.InvariantCulture),
          Positioncount = f.Random.Int(1, 100).ToString(),
          Sector = f.Random.Words().ToString()
        });
    var feed = feedEntry.Generate();
    return feed;
  }
}
