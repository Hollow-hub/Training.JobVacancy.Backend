namespace Adaptit.Training.JobVacancy.Backend.Dto;

using System.Text.Json.Serialization;

public class FeedEntry
{
  public required string Uuid { get; set; }
  public required string SistEndret { get; set; }
  public required string Status { get; set; }

  [JsonPropertyName("ad_content")]
  public required AdContent AdContent { get; set; }
}

public class AdContent
{
  public required string Uuid { get; set; }
  public required string Published { get; set; }
  public required string Expires { get; set; }
  public required string Updated { get; set; }
  public required WorkLocations[] WorkLocations { get; set; }
  public required ContactList[] ContactList { get; set; }
  public required string Title { get; set; }
  public string? Description { get; set; }
  public string? Sourceurl { get; set; }
  public string? Source { get; set; }
  public string? ApplicationUrl { get; set; }
  public string? ApplicationDue { get; set; }
  public required OccupationCategories[] OccupationCategories { get; set; }
  public required CategoryList[] CategoryList { get; set; }
  public string? Jobtitle { get; set; }
  public required string Link { get; set; }
  public required Employer Employer { get; set; }
  public string? Engagementtype { get; set; }
  public string? Extent { get; set; }
  public string? Starttime { get; set; }
  public string? Positioncount { get; set; }
  public string? Sector { get; set; }
}

public class WorkLocations
{
  public string? Country { get; set; }
  public string? Address { get; set; }
  public string? City { get; set; }
  public string? PostalCode { get; set; }
  public string? County { get; set; }
  public string? Municipal { get; set; }
}

public class ContactList
{
  public string? Name { get; set; }
  public string? Email { get; set; }
  public string? Phone { get; set; }
  public string? Role { get; set; }
  public string? Title { get; set; }
}

public class OccupationCategories
{
  public required string Level1 { get; set; }
  public required string Level2 { get; set; }
}

public class CategoryList
{
  public required string CategoryType { get; set; }
  public required string Code { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public required int Score { get; set; }
}

public class Employer
{
  public required string Name { get; set; }
  public string? Orgnr { get; set; }
  public string? Description { get; set; }
  public string? Homepage { get; set; }
}
