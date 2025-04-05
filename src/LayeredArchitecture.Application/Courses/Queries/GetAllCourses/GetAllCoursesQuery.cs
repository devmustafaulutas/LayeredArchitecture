using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.Courses.Queries.GetAllCourses;

public class GetAllCoursesQuery(ILayeredArchitectureDbContext dbContext)
{
    public List<CourseDto> Handle()
    {
        return dbContext.Courses
            .Select(course => new CourseDto(course.Id, course.Name,course.Time, course.Quota))
            .ToList();
    }
}