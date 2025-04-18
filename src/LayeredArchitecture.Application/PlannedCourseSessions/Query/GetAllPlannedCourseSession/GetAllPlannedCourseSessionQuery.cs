using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourseSessions.Query.GetAllPlannedCourseSession;

public class GetAllPlannedCourseSessionQuery(ILayeredArchitectureDbContext dbContext)
{
    public List<PlannedCourseSessionCommand> Handle(){
        var plannedCourseSessions =  dbContext.PlannedCourseSessions
            .Include(p => p.plannedCourse)
            .Select(p => new PlannedCourseSessionCommand(
                p.Id,
                p.plannedCourse.Id,
                p.plannedCourse.Course.Name,
                p.plannedCourse.DayOfWeek,
                p.plannedCourse.StartTime,
                p.date
            ))
            .ToList();
        return plannedCourseSessions;

    }
}