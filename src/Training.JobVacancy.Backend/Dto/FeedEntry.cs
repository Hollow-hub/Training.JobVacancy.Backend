namespace Adaptit.Training.JobVacancy.Backend.Dto;

public class FeedEntry
{
  public string uuid { get; set; }
  public string sistEndret { get; set; }
  public string status { get; set; }
  public Ad_content ad_content { get; set; }
}

public class Ad_content
{
  public string uuid { get; set; }
  public string published { get; set; }
  public string expires { get; set; }
  public string updated { get; set; }
  public WorkLocations[] workLocations { get; set; }
  public ContactList[] contactList { get; set; }
  public string title { get; set; }
  public string description { get; set; }
  public string sourceurl { get; set; }
  public string source { get; set; }
  public string applicationUrl { get; set; }
  public string applicationDue { get; set; }
  public OccupationCategories[] occupationCategories { get; set; }
  public CategoryList[] categoryList { get; set; }
  public string jobtitle { get; set; }
  public string link { get; set; }
  public Employer employer { get; set; }
  public string engagementtype { get; set; }
  public string extent { get; set; }
  public string starttime { get; set; }
  public string positioncount { get; set; }
  public string sector { get; set; }
}

public class WorkLocations
{
  public string country { get; set; }
  public string address { get; set; }
  public string city { get; set; }
  public string postalCode { get; set; }
  public string county { get; set; }
  public string municipal { get; set; }
}

public class ContactList
{
  public string name { get; set; }
  public string email { get; set; }
  public string phone { get; set; }
  public string role { get; set; }
  public string title { get; set; }
}

public class OccupationCategories
{
  public string level1 { get; set; }
  public string level2 { get; set; }
}

public class CategoryList
{
  public string categoryType { get; set; }
  public string code { get; set; }
  public string name { get; set; }
  public string description { get; set; }
  public int score { get; set; }
}

public class Employer
{
  public string name { get; set; }
  public string orgnr { get; set; }
  public string description { get; set; }
  public string homepage { get; set; }
}
