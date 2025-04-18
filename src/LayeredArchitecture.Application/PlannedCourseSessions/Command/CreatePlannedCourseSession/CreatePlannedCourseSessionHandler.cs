using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourseSessions.Command.CreatePlannedCourseSession;
public class CreatePlannedCourseSessionHandler(ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(CreatePlannedCourseSessionCommand createPlannedCourseSessionCommand)
    {
        var plannedCourseSession = PlannedCourseSession.Create(createPlannedCourseSessionCommand.plannedCourseId , createPlannedCourseSessionCommand.date);
        if(plannedCourseSession is null)
            throw new Exception($"PlannedCourseSession for create is null ! ");
        dbContext.PlannedCourseSessions.Add(plannedCourseSession);
        dbContext.SaveChanges();
        return plannedCourseSession.Id;
    }
}