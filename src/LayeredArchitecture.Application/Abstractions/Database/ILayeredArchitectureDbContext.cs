using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.Abstractions.Database;

public interface ILayeredArchitectureDbContext
{
    DbSet<Course> Courses { get; }
    DbSet<PlannedCourse> PlannedCourses { get; }

    int SaveChanges();
}