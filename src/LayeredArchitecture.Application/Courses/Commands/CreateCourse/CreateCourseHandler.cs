using FluentValidation;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseHandler
    {
        public static async Task<Guid> Handle(CreateCourseCommand command,
        IValidator<CreateCourseCommand> validator ,
        ILayeredArchitectureDbContext dbContext
        )

        {
            var validation = await validator.ValidateAsync(command);
            if(validation.IsValid)
                throw new ValidationException(validation.Errors);

            var course = Course.Create(command.Name , command.Quota , command.Time);
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            return course.Id;
        }
    }
    // public class CreateCourseCommand(ILayeredArchitectureDbContext dbContext , IValidator<CreateCourseDto> validator)
    // {
    //     public Guid Handle( courseDto)
    //     {
    //         var validation = validator.Validate(courseDto);
    //         if (!validation.IsValid)
    //             throw new ValidationException(validation.Errors);


    //         var course = Course.Create(courseDto.Name, courseDto.Quota, courseDto.Time);
    //         dbContext.Courses.Add(course);
    //         dbContext.SaveChanges();
    //         return course.Id;
    //     }
    // }
}
