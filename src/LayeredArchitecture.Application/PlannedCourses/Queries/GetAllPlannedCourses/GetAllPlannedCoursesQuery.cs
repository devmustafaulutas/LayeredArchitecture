using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourses.Queries;

public class GetAllPlannedCoursesQuery(ILayeredArchitectureDbContext dbContext)
{
    public List<PlannedCourseCommand> Handle()
    {
        var courses = dbContext.PlannedCourses
            .Include(p => p.Course)  
            .Select(p => new PlannedCourseCommand(
                p.Id,
                p.CourseId,
                p.Course.Name,
                p.DayOfWeek,
                p.StartTime,  
                p.Course.Quota  
            ))
            .ToList();
        return courses;
    }
}