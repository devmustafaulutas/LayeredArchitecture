using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.plannedCourseSession.DeletePlannedCourseSession;

public class DeleteAllPlannedCourseSessionCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle()
    {
        var pcs = dbContext.PlannedCourseSessions.ToList();
        if(pcs is null)
            throw new Exception($"PlannedCourse's for delete all is null ! ");
        dbContext.PlannedCourseSessions.RemoveRange(pcs);
        dbContext.SaveChanges();
    }
}