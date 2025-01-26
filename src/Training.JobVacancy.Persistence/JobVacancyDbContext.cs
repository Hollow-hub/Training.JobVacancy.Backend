namespace Adaptit.Training.JobVacancy.Persistence;

using Microsoft.EntityFrameworkCore;

public class JobVacancyDbContext(DbContextOptions<JobVacancyDbContext> options) : DbContext(options)
{

}
