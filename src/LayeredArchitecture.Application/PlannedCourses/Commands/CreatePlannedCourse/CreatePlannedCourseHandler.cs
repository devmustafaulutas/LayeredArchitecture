using FluentValidation;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.Validators.PlannedCourse;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;

public class CreatePlannedCourseHandler
{   
    private readonly ILayeredArchitectureDbContext _dbContext;
    private readonly CreatePlannedCourseValidator validator;
    public CreatePlannedCourseHandler(ILayeredArchitectureDbContext dbContext , CreatePlannedCourseValidator createValidator)
    {
        _dbContext = dbContext;
        validator = createValidator;
    }
    public async Task<Guid> Handle(CreatePlannedCourseCommand command)
    {
        var validation = await validator.ValidateAsync(command);
        if(!validation.IsValid)
            throw new ValidationException(validation.Errors);
            
        var plannedCourse = PlannedCourse.Create(command.courseId , command.day , command.startTime);
        _dbContext.PlannedCourses.Add(plannedCourse);
        await _dbContext.SaveChangesAsync();
        return plannedCourse.Id;
    }
}