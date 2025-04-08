using System.ComponentModel.DataAnnotations;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.Validators.Course;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand
    {
        private readonly ILayeredArchitectureDbContext _dbContext;
        private readonly CreateCourseValidator _validator;
        public CreateCourseCommand(ILayeredArchitectureDbContext dbContext, CreateCourseValidator validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public Guid Handle(CreateCourseDto courseDto)
        {
            var isValid = _validator.Validate(courseDto);
            if (!isValid)
            {
                throw new ValidationException("Course validation Error: Time must be between 15 and 60 minutes and a multiple of 15.");
            }
            var course = Course.Create(courseDto.Name, courseDto.Quota, courseDto.Time);

            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            return course.Id;
        }
    }
}
