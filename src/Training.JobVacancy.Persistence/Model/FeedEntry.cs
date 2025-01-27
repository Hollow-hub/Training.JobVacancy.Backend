namespace Adaptit.Training.JobVacancy.Persistence.Model;

public class FeedEntry
{
  public string Uuid { get; set; }

  public string SistEndret { get; set; }

  public string Status { get; set; }
  public AdContent AdContent { get; set; }
}

public class AdContent
{
  public string Uuid { get; set; }

  public string Published { get; set; }

  public string Expires { get; set; }

  public string Updated { get; set; }

  public ICollection<WorkLocation> WorkLocations { get; set; } = [];

  public ICollection<Contact> ContactList { get; set; } = [];

  public string Title { get; set; }

  public string? Description { get; set; }

  public string? Sourceurl { get; set; }

  public string? Source { get; set; }

  public string? ApplicationUrl { get; set; }

  public string? ApplicationDue { get; set; }

  public ICollection<OccupationCategory> OccupationCategories { get; set; } = [];

  public ICollection<Category> CategoryList { get; set; } = [];

  public string? Jobtitle { get; set; }

  public string Link { get; set; }

  public Employer Employer { get; set; }

  public string? Engagementtype { get; set; }

  public string? Extent { get; set; }

  public string? Starttime { get; set; }

  public string? Positioncount { get; set; }

  public string? Sector { get; set; }
}

public class WorkLocation
{
  public int Id { get; set; }

  public string? Country { get; set; }

  public string? Address { get; set; }

  public string? City { get; set; }

  public string? PostalCode { get; set; }

  public string? County { get; set; }

  public string? Municipal { get; set; }

  public string AdContentUuid { get; set; }

  public AdContent AdContent { get; set; }
}

public class Contact
{
  public int Id { get; set; }

  public string? Name { get; set; }

  public string? Email { get; set; }

  public string? Phone { get; set; }

  public string? Role { get; set; }

  public string? Title { get; set; }


  public string AdContentUuid { get; set; }

  public AdContent AdContent { get; set; }
}

public class OccupationCategory
{
  public int Id { get; set; }

  public string Level1 { get; set; }

  public string Level2 { get; set; }


  public string AdContentUuid { get; set; }

  public AdContent AdContent { get; set; }
}

public class Category
{
  public int Id { get; set; }

  public string CategoryType { get; set; }

  public string Code { get; set; }

  public string Name { get; set; }

  public string? Description { get; set; }

  public int Score { get; set; }

  public string AdContentUuid { get; set; }

  public AdContent AdContent { get; set; }
}

public class Employer
{
  public string Name { get; set; }

  public string? Orgnr { get; set; }

  public string? Description { get; set; }

  public string? Homepage { get; set; }
}
