using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.Courses.Queries.GetAllCourses;

namespace LayeredArchitecture.Application.Courses.Commands.DeleteCourse;
public class DeleteAllCoursesHandler(ILayeredArchitectureDbContext dbContext)
{
    public void Handle()
    {
        var allCourses = dbContext.Courses.ToList();
        dbContext.Courses.RemoveRange(allCourses);
        dbContext.SaveChanges();
    }
}