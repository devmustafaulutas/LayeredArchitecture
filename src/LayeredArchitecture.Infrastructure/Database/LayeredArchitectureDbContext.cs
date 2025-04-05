using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Infrastructure.Database;

public class LayeredArchitectureDbContext : DbContext, ILayeredArchitectureDbContext
{
    public LayeredArchitectureDbContext(DbContextOptions<LayeredArchitectureDbContext> options) : base(options)
    {
    }
    
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<PlannedCourse> PlannedCourses { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LayeredArchitectureDbContext).Assembly);
    }
}