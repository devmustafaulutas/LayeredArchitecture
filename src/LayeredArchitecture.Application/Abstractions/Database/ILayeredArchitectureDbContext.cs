using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.Abstractions.Database;

public interface ILayeredArchitectureDbContext
{
    DbSet<Course> Courses { get; }
    DbSet<PlannedCourse> PlannedCourses { get; }
    DbSet<PlannedCourseSession> plannedCourseSessions {get;}
    DbSet<PlannedCourseSessionDiscontinuity> plannedCourseSessionDiscontinuities {get ;}
    DbSet<Student> students {get;}
    DbSet<StudentPayment> studentPayments {get ;}
    int SaveChanges();
}