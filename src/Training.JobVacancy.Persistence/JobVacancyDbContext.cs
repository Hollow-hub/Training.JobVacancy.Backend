namespace Adaptit.Training.JobVacancy.Persistence;

using Adaptit.Training.JobVacancy.Persistence.Model;

using Microsoft.EntityFrameworkCore;

public class JobVacancyDbContext(DbContextOptions<JobVacancyDbContext> options) : DbContext(options)
{
  public DbSet<Feed> Feeds { get; set; }

  public DbSet<Item> Items { get; set; }

  public DbSet<feedEntry> feedEntries { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Feed>(e =>
    {
      e.HasKey(f => f.Id);
      e.HasMany(f => f.Items)
        .WithOne(i => i.Feed)
        .OnDelete(DeleteBehavior.Restrict);
    });

    modelBuilder.Entity<Item>()
      .HasKey(i => i.Id);

    modelBuilder.Entity<feedEntry>()
      .HasKey(f => f.Uuid);
  }
}
