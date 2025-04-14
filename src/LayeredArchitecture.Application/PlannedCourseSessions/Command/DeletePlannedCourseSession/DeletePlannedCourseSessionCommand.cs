using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.plannedCourseSession.DeletePlannedCourseSession;
public class DeletePlannedCOurseCommand (ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid id)
    {
        var session = dbContext.PlannedCourseSessions.Find(id);
        if(session is null)
            throw new Exception($"PlannedCourseSession for delete is null!");
        dbContext.PlannedCourseSessions.Remove(session);
        dbContext.SaveChanges();
    }
}