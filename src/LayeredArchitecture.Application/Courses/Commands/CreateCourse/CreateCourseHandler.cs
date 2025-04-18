using FluentValidation;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseHandler(ILayeredArchitectureDbContext dbContext ,
        IValidator<CreateCourseCommand> validator)
    {
        public async Task<Guid> Handle(CreateCourseCommand command)
        {
            var validation = await validator.ValidateAsync(command);
            if(!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var course = Course.Create(command.Name , command.Quota , command.Time);
            dbContext.Courses.Add(course);
            await dbContext.SaveChangesAsync();
            return course.Id;
        }
    }
}
