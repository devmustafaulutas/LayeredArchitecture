using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;

public class CreatePlannedCourseCommand(ILayeredArchitectureDbContext dbContext)
{   
    public Guid Handle(CreatePlannedCourseDto createplannedCourseDto)
    {
        var plannedCourse = PlannedCourse.Create(createplannedCourseDto.courseId , createplannedCourseDto.day , createplannedCourseDto.startTime);
        dbContext.PlannedCourses.Add(plannedCourse);
        dbContext.SaveChanges();
        return plannedCourse.Id;
    }
}