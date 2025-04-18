using LayeredArchitecture.Application.Abstractions.Database;

namespace  LayeredArchitecture.Application.PlannedCourses.Commands.UpdatePlannedCourse;
public class UpdatePlannedCourseHandler(ILayeredArchitectureDbContext dbContext)
{

    public async Task<Guid> Handle( Guid  plannedCourseId , UpdatePlannedCourseCommand command)
    {
        var plannedCourse = await dbContext.PlannedCourses.FindAsync(plannedCourseId);
        if (plannedCourse is not null)
        {
            plannedCourse.Update(command.day ,command.startTime);
            dbContext.PlannedCourses.Update(plannedCourse);
            await dbContext.SaveChangesAsync();
        }
        else{
            throw new Exception("Planned Course is null");
        }
        return plannedCourseId;
    }
}