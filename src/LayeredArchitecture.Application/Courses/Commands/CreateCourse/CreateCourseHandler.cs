using FluentValidation;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseHandler
    {
        private readonly ILayeredArchitectureDbContext _dbContext;
        private readonly IValidator<CreateCourseCommand> _validator;
        public CreateCourseHandler(ILayeredArchitectureDbContext dbContext , IValidator<CreateCourseCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }
        public async Task<CreateCourseCommand> Handle(CreateCourseCommand command)
        {
            // Validation
            var validation = await _validator.ValidateAsync(command);
            if(!validation.IsValid)
                throw new ValidationException(validation.Errors);
            
            // Create
            var course = Course.Create(command.Name , command.Quota , command.Time);
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();

            return new CreateCourseCommand(course.Name , course.Time , course.Quota);
        }

        // public async Task<Guid> Handle(CreateCourseCommand command)
        // {
        //     var validation = await validator.ValidateAsync(command);
        //     if(!validation.IsValid)
        //         throw new ValidationException(validation.Errors);

        //     var course = Course.Create(command.Name , command.Quota , command.Time);
        //     dbContext.Courses.Add(course);
        //     await dbContext.SaveChangesAsync();
        //     return course.Id;
        // }
    }
}
