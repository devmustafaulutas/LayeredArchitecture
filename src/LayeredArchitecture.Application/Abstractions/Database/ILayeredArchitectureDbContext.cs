using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.Abstractions.Database;

public interface ILayeredArchitectureDbContext
{
    DbSet<Course> Courses { get; }
    DbSet<PlannedCourse> PlannedCourses { get; }
    DbSet<PlannedCourseSession> PlannedCourseSessions {get;}
    DbSet<PlannedCourseSessionDiscontinuity> PlannedCourseSessionDiscontinuities {get ;}
    DbSet<Student> Students {get;}
    DbSet<StudentPayment> StudentPayments {get ;}
    int SaveChanges();
}