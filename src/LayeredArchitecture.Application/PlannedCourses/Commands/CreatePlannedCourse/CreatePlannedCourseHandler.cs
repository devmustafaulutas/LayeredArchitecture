using FluentValidation;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.Validators.PlannedCourse;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;

public class CreatePlannedCourseHandler(ILayeredArchitectureDbContext dbContext , CreatePlannedCourseValidator createValidator)
{   
    public async Task<Guid> Handle(CreatePlannedCourseCommand command)
    {
        var validation = await createValidator.ValidateAsync(command);
        if(!validation.IsValid)
            throw new ValidationException(validation.Errors);
            
        var plannedCourse = PlannedCourse.Create(command.courseId , command.day , command.startTime);
        dbContext.PlannedCourses.Add(plannedCourse);
        await dbContext.SaveChangesAsync();
        return plannedCourse.Id;
    }
}