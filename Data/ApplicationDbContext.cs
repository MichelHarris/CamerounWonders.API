using CamerounWonders.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CamerounWonders.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Region> Regions => Set<Region>();
    public DbSet<User> Users => Set<User>();
    public DbSet<TouristSite> TouristSites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>();
        modelBuilder.Entity<Region>();
    }
}