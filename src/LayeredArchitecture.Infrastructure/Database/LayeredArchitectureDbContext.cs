using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LayeredArchitecture.Infrastructure.Database;

public class LayeredArchitectureDbContext : DbContext, ILayeredArchitectureDbContext
{
    public LayeredArchitectureDbContext(DbContextOptions<LayeredArchitectureDbContext> options) : base(options)
    {
    }
    //migration
    // dotnet ef migrations add Initial --startup-project ..\LayeredArchitecture.Presentation --output-dir .\Database\Migrations --project ..\LayeredArchitecture.Infrastructure
    //db update
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<PlannedCourse> PlannedCourses { get; set; }
    public DbSet<PlannedCourseSession> plannedCourseSessions {get ; set;}
    public DbSet<PlannedCourseSessionDiscontinuity> plannedCourseSessionDiscontinuities { get; set; }
    public DbSet<Student> students { get; set; }
    public DbSet<StudentPayment> studentPayments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LayeredArchitectureDbContext).Assembly);
    }

}