using LayeredArchitecture.Application.Abstractions.Database;

namespace  LayeredArchitecture.Application.PlannedCourses.Commands.UpdatePlannedCourse;
public class UpdatePlannedCourseHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public UpdatePlannedCourseHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> Handle( UpdatePlannedCourseCommand command)
    {
        var plannedCourse = await _dbContext.PlannedCourses.FindAsync(command.plannedCourseId);
        if (plannedCourse is not null)
        {
            plannedCourse.Update(command.day ,command.startTime);
            _dbContext.PlannedCourses.Update(plannedCourse);
            await _dbContext.SaveChangesAsync();
        }
        else{
            throw new Exception("Planned Course is null");
        }
        return command.plannedCourseId;
    }
}