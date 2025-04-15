using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourseSessions.Command.CreatePlannedCourseSession;
public class CreatePlannedCourseSessionCommand(ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(CreatePlannedCourseSessionDto createPlannedCourseSessionDto)
    {
        var plannedCourseSession = PlannedCourseSession.Create(createPlannedCourseSessionDto.plannedCourseSessionId , createPlannedCourseSessionDto.date);
        if(plannedCourseSession is null)
            throw new Exception($"PlannedCourseSession for create is null ! ");
        dbContext.PlannedCourseSessions.Add(plannedCourseSession);
        dbContext.SaveChanges();
        return plannedCourseSession.Id;
    }
}