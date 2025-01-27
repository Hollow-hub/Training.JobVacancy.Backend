namespace Adaptit.Training.JobVacancy.Persistence;

using Adaptit.Training.JobVacancy.Persistence.Model;

using Microsoft.EntityFrameworkCore;

public class JobVacancyDbContext(DbContextOptions<JobVacancyDbContext> options) : DbContext(options)
{
  public DbSet<Feed> Feeds { get; set; }

  public DbSet<Item> Items { get; set; }

  public DbSet<feedEntry> feedEntries { get; set; }

  public DbSet<FeedEntry> FeedEntries { get; set; }

  public DbSet<AdContent> AdContents { get; set; }

  public DbSet<WorkLocation> WorkLocations { get; set; }

  public DbSet<Contact> Contacts { get; set; }

  public DbSet<OccupationCategory> OccupationCategories { get; set; }

  public DbSet<Category> Categories { get; set; }

  public DbSet<Employer> Employers { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Feed>()
      .HasKey(f => f.Id);

    modelBuilder.Entity<Feed>()
      .HasMany(f => f.Items)
      .WithOne(i => i.Feed)
      .HasForeignKey(i => i.FeedId)
      .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Item>()
      .HasKey(i => i.Id);

    modelBuilder.Entity<feedEntry>()
      .HasKey(f => f.Uuid);


    modelBuilder.Entity<FeedEntry>()
      .HasKey(fe => fe.Uuid);

    modelBuilder.Entity<FeedEntry>()
      .HasOne(fe => fe.AdContent)
      .WithOne()
      .HasForeignKey<AdContent>(ac => ac.Uuid);

    modelBuilder.Entity<AdContent>()
      .HasKey(ac => ac.Uuid);

    modelBuilder.Entity<AdContent>()
      .HasOne(ac => ac.Employer)
      .WithOne()
      .HasForeignKey<Employer>(e => e.Name);

    modelBuilder.Entity<WorkLocation>()
      .HasOne(wl => wl.AdContent)
      .WithMany(ac => ac.WorkLocations)
      .HasForeignKey(wl => wl.AdContentUuid);

    modelBuilder.Entity<Contact>()
      .HasOne(c => c.AdContent)
      .WithMany(ac => ac.ContactList)
      .HasForeignKey(c => c.AdContentUuid);

    modelBuilder.Entity<OccupationCategory>()
      .HasOne(oc => oc.AdContent)
      .WithMany(ac => ac.OccupationCategories)
      .HasForeignKey(oc => oc.AdContentUuid);

    modelBuilder.Entity<Category>()
      .HasOne(c => c.AdContent)
      .WithMany(ac => ac.CategoryList)
      .HasForeignKey(c => c.AdContentUuid);
  }
}
