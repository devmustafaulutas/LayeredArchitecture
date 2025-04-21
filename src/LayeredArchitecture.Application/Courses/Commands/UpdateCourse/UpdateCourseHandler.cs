using FluentValidation;
using LayeredArchitecture.Application.Abstractions.Database;
namespace LayeredArchitecture.Application.Courses.Commands.UpdateCourse;

public class UpdateCourseHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    private readonly IValidator<UpdateCourseCommand> _validator;
    public UpdateCourseHandler(ILayeredArchitectureDbContext dbContext ,IValidator<UpdateCourseCommand> validator)
    {
        _validator = validator;
        _dbContext = dbContext;
    }
    public async Task Handle(UpdateCourseCommand command)
    {
        // Validation
        var validation = _validator.Validate(command);
        if(!validation.IsValid)
            throw new ValidationException(validation.Errors);

        // Course check
        var course = await _dbContext.Courses.FindAsync(command.Id);
        if(course is null)
            throw new Exception("Course is null !");

        course.Update(command.Name, command.Quota,command.Time);
        _dbContext.Courses.Update(course);
        await _dbContext.SaveChangesAsync();
    }
}