namespace Adaptit.Training.JobVacancy.Backend;

using System.ComponentModel.DataAnnotations;

public class NaviktSettings
{
  [Required(AllowEmptyStrings = false)]
  public string ApiKey { get; set; } = string.Empty;
}
