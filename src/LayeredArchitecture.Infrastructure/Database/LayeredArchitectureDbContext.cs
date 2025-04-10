using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Infrastructure.Database;

public class LayeredArchitectureDbContext : DbContext, ILayeredArchitectureDbContext
{
    public LayeredArchitectureDbContext(DbContextOptions<LayeredArchitectureDbContext> options) : base(options)
    {
    }
    //migration
    // dotnet ef migrations add Initial --startup-project ..\LayeredArchitecture.Presentation --output-dir .\Database\Migrations --project ..\LayeredArchitecture.Infrastructure
    //migration remove
    // dotnet ef migrations remove --startup-project ..\LayeredArchitecture.Presentation --project ..\LayeredArchitecture.Infrastructure
    //db update
    // dotnet ef database update --startup-project ..\LayeredArchitecture.Presentation --project ..\LayeredArchitecture.Infrastructure


    public DbSet<Course> Courses { get; set; }
    public DbSet<PlannedCourse> PlannedCourses { get; set; }
    public DbSet<PlannedCourseSession> PlannedCourseSessions {get ; set;}
    public DbSet<PlannedCourseSessionDiscontinuity> PlannedCourseSessionDiscontinuities { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentPayment> StudentPayments { get; set; }
    public DbSet<PlannedCourseStudent> PlannedCourseStudents { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LayeredArchitectureDbContext).Assembly);
    }
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}