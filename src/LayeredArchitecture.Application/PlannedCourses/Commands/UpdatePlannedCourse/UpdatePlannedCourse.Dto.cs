using LayeredArchitecture.Application.Abstractions.Database;

namespace  LayeredArchitecture.Application.PlannedCourses.Commands.UpdatePlannedCourse;
public class UpdatePlannedCourseCommand(ILayeredArchitectureDbContext dbContext)
{

    public void Handle( Guid  plannedCourseId , UpdatePlannedCourseDto updatePlannedCourseDto )
    {
        var plannedCourse = dbContext.PlannedCourses.Find(plannedCourseId);
        if (plannedCourse is not null)
        {
            plannedCourse.Update(updatePlannedCourseDto.day ,updatePlannedCourseDto.startTime);
            dbContext.PlannedCourses.Update(plannedCourse);
            dbContext.SaveChanges();
        }
        else{
            throw new Exception("Planned Course is null");
        }
    }
}