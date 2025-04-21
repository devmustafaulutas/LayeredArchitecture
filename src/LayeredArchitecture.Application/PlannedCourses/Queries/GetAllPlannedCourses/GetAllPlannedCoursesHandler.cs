using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.PlannedCourses.Queries.GetAllPlannedCourses;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourses.Queries;

public class GetAllPlannedCoursesHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public GetAllPlannedCoursesHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<PlannedCourseCommand>> Handle(GetAllPlannedCourseQuery query)
    {
        var courses =await  _dbContext.PlannedCourses
            .Include(p => p.Course)  
            .Select(p => new PlannedCourseCommand(
                p.Id,
                p.CourseId,
                p.Course.Name,
                p.DayOfWeek,
                p.StartTime,  
                p.Course.Quota  
            ))
            .ToListAsync();
        return courses;
    }
}