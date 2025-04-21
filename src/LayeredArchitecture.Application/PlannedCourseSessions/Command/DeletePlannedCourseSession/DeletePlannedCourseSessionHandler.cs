using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.PlannedCourseSessions.Command.DeletePlannedCourseSession;

namespace LayeredArchitecture.Application.plannedCourseSession.DeletePlannedCourseSession;
public class DeletePlannedCOurseCommand 
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public DeletePlannedCOurseCommand (ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(DeletePlannedCourseSessionCommand command)
    {
        var session = await _dbContext.PlannedCourseSessions.FindAsync(command.Id);
        if(session is null)
            throw new Exception($"PlannedCourseSession for delete is null!");
        _dbContext.PlannedCourseSessions.Remove(session);
        await _dbContext.SaveChangesAsync();
    }
}