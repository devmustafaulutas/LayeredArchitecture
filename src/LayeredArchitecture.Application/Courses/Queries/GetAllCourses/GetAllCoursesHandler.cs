using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.Courses.Queries.GetAllCourses;

public class GetAllCoursesHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public GetAllCoursesHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<CourseCommand>> Handle(GetAllCoursesQuery query)
    {   
        return await _dbContext.Courses
            .Select(course =>new CourseCommand(course.Id, course.Name,course.Time, course.Quota))
            .ToListAsync();
    }
}