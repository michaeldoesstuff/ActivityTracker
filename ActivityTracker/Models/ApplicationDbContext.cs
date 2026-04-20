using Microsoft.EntityFrameworkCore;

namespace ActivityTracker.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<ActivityModel> Activities { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ActivityModel>().HasData(new ActivityModel
        {
            Id = 1,
            Name = "Sample Activity",
            Date = "Wednesday at 8:00",
        });
    }
}