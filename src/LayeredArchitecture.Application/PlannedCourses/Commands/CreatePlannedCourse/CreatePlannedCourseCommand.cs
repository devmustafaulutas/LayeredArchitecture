using FluentValidation;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.PlannedCourses.Queries;
using LayeredArchitecture.Application.Validators.PlannedCourse;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;

public class CreatePlannedCourseCommand(ILayeredArchitectureDbContext dbContext , CreatePlannedCourseValidator createValidator)
{   
    public Guid Handle(CreatePlannedCourseDto createplannedCourseDto )
    {
        var validation = createValidator.Validate(createplannedCourseDto);
        if(!validation.IsValid)
            throw new ValidationException(validation.Errors);
            
        var plannedCourse = PlannedCourse.Create(createplannedCourseDto.courseId , createplannedCourseDto.day , createplannedCourseDto.startTime);
        dbContext.PlannedCourses.Add(plannedCourse);
        dbContext.SaveChanges();
        return plannedCourse.Id;
    }
}