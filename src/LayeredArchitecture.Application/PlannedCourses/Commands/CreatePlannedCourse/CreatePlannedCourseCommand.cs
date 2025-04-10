using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.PlannedCourses.Queries;
using LayeredArchitecture.Application.Validators.PlannedCourse;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;

public class CreatePlannedCourseCommand(ILayeredArchitectureDbContext dbContext , CreatePlannedCourseValidator createPlannedCourseValidation)
{   
    public Guid Handle(CreatePlannedCourseDto createplannedCourseDto )
    {
        var plannedCourse = PlannedCourse.Create(createplannedCourseDto.courseId , createplannedCourseDto.day , createplannedCourseDto.startTime);
        var result = createPlannedCourseValidation.IsTimeAvaliable(createplannedCourseDto);
        if(result is false)
            throw new Exception("Time is not avaliable");
        dbContext.PlannedCourses.Add(plannedCourse);
        dbContext.SaveChanges();
        return plannedCourse.Id;
    }
}