using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.Validators.CourseValidations;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.Courses.Commands.CreateCourse;

public class CreateCourseCommand
{    
    private readonly ILayeredArchitectureDbContext dbContext;
    private readonly CreateCourseValidation validation;

    public CreateCourseCommand(ILayeredArchitectureDbContext _dbContext , CreateCourseValidation _validation)
    {
        dbContext = _dbContext;
        validation = _validation;
    }
    public Guid Handle(CreateCourseDto courseDto)
    {
        validation.Validate(courseDto);
        
        var course = Course.Create(courseDto.Name,courseDto.Quota, courseDto.Time);

        dbContext.Courses.Add(course);
        dbContext.SaveChanges();

        return course.Id;
    }
}