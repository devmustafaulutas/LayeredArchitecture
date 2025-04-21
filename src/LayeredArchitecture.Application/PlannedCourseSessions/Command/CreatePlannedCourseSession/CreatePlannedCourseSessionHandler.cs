using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourseSessions.Command.CreatePlannedCourseSession;
public class CreatePlannedCourseSessionHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public CreatePlannedCourseSessionHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> Handle(CreatePlannedCourseSessionCommand createPlannedCourseSessionCommand)
    {
        var plannedCourseSession = PlannedCourseSession.Create(createPlannedCourseSessionCommand.plannedCourseId , createPlannedCourseSessionCommand.date);
        if(plannedCourseSession is null)
            throw new Exception($"PlannedCourseSession for create is null ! ");
        await _dbContext.PlannedCourseSessions.AddAsync(plannedCourseSession);
        await _dbContext.SaveChangesAsync();
        return plannedCourseSession.Id;
    }
}