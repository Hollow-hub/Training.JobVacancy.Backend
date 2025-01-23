using System.Globalization;

using Adaptit.Training.JobVacancy.Backend.Dto;

using Bogus;

namespace Adaptit.Training.JobVacancy.Backend.Data
{
  public static class DataCreatorFeed
  {
    public static Feed GetFeed()
    {
      var feedItems = new Faker<Items>()
        .RuleFor(q => q.id, f => f.Random.Int(1, 100).ToString())
        .RuleFor(q => q.url, f => "https://localhost:5001/api/v1/feed/1")
        .RuleFor(q => q.title, q => q.Random.Words())
        .RuleFor(q => q.content_text, q => q.Random.Words())
        .RuleFor(q => q.date_modified, f => f.Date.Past().ToString(CultureInfo.InvariantCulture))
        .RuleFor(q => q._feed_entry,
          f => new _feed_entry
          {
            uuid = f.Random.Guid().ToString(),
            status = "Active",
            title = f.Random.Words(),
            businessName = f.Random.Words(),
            municipal = f.Random.Words(),
            sistEndret = f.Date.Past().ToString(CultureInfo.InvariantCulture)
          });

      var feedFaker = new Faker<Feed>()
        .RuleFor(q => q.version, f => "https://jsonfeed.org/version/1")
        .RuleFor(q => q.title, q => q.Random.Words().ToString())
        .RuleFor(q => q.home_page_url, f => "https://localhost:5001/api/v1/feed")
        .RuleFor(q => q.feed_url, f => "https://localhost:5001/api/v1/feed")
        .RuleFor(q => q.description, q => q.Random.Words().ToString())
        .RuleFor(q => q.next_url, f => "https://localhost:5001/api/v1/feed/2")
        .RuleFor(q => q.id, q => q.Random.Int(1, 100).ToString())
        .RuleFor(q => q.next_id, q => q.Random.Int(1, 100).ToString())
        .RuleFor(q => q.items, q => [.. feedItems.Generate(1)]);

      var feed = feedFaker.Generate();
      return feed;
    }


    public static FeedEntry GetFeedEntry()
    {
      var feedEntry = new Faker<FeedEntry>()
        .RuleFor(q => q.uuid, q => q.Random.Guid().ToString())
        .RuleFor(q => q.sistEndret, f => f.Date.Past().ToString(CultureInfo.InvariantCulture))
        .RuleFor(q => q.status, f => "Active")
        .RuleFor(q => q.ad_content,
          f => new Ad_content
          {
            uuid = f.Random.Guid().ToString(),
            published = f.Date.Past().ToString(CultureInfo.InvariantCulture),
            expires = f.Date.Future().ToString(CultureInfo.InvariantCulture),
            updated = f.Date.Future().ToString(CultureInfo.InvariantCulture),
            workLocations =
            [
              new WorkLocations
              {
                country = f.Address.Country().ToString(),
                address = f.Address.StreetAddress().ToString(),
                city = f.Address.City().ToString(),
                postalCode = f.Address.ZipCode().ToString(),
                county = f.Address.County().ToString(),
                municipal = f.Address.City().ToString()
              }
            ],
            contactList =
            [
              new ContactList
              {
                name = f.Name.FullName().ToString(),
                email = f.Internet.Email().ToString(),
                phone = f.Phone.PhoneNumber().ToString(),
                role = f.Random.Words().ToString(),
                title = f.Random.Words().ToString()
              }
            ],
            title = f.Random.Words().ToString(),
            description = f.Random.Words().ToString(),
            sourceurl = f.Internet.Url().ToString(),
            source = f.Random.Words().ToString(),
            applicationUrl = f.Internet.Url().ToString(),
            applicationDue = f.Date.Future().ToString(CultureInfo.InvariantCulture),
            occupationCategories =
            [
              new OccupationCategories
              {
                level1 = f.Random.Words().ToString(),
                level2 = f.Random.Words().ToString()
              }
            ],
            categoryList =
            [
              new CategoryList
              {
                categoryType = f.Random.Words().ToString(),
                code = f.Random.Words().ToString(),
                name = f.Random.Words().ToString(),
                description = f.Random.Words().ToString(),
                score = f.Random.Int(1, 100)
              }
            ],
            jobtitle = f.Random.Words().ToString(),
            link = f.Internet.Url().ToString(),
            employer = new Employer
            {
              name = f.Company.CompanyName().ToString(),
              orgnr = f.Random.Int(100000, 999999).ToString(),
              description = f.Random.Words().ToString(),
              homepage = f.Internet.Url().ToString()
            },
            engagementtype = f.Random.Words().ToString(),
            extent = f.Random.Words().ToString(),
            starttime = f.Date.Future().ToString(CultureInfo.InvariantCulture),
            positioncount = f.Random.Int(1, 100).ToString(),
            sector = f.Random.Words().ToString()
          });
      var feed = feedEntry.Generate();
      return feed;
    }
  }
}
