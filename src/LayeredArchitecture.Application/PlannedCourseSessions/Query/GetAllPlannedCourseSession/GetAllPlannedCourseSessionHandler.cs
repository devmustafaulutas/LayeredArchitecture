using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourseSessions.Query.GetAllPlannedCourseSession;

public class GetAllPlannedCourseSessionHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public GetAllPlannedCourseSessionHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<PlannedCourseSessionCommand>> Handle(){
        var plannedCourseSessions = await _dbContext.PlannedCourseSessions
            .Include(p => p.plannedCourse)
            .Select(p => new PlannedCourseSessionCommand(
                p.Id,
                p.plannedCourse.Id,
                p.plannedCourse.Course.Name,
                p.plannedCourse.DayOfWeek,
                p.plannedCourse.StartTime,
                p.date
            ))
            .ToListAsync();
        return plannedCourseSessions;

    }
}