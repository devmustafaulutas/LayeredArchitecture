using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.Validators.Course;
namespace LayeredArchitecture.Application.Courses.Commands.UpdateCourse;

public class UpdateCourseCommand(ILayeredArchitectureDbContext dbContext , UpdateCourseValidator validator)
{
    public void Handle(Guid courseId, UpdateCourseDto courseDto)
    {
        validator.Validate(courseDto);

        var course = dbContext.Courses.Find(courseId);

        course.Update(courseDto.Name, courseDto.Quota,courseDto.Time);

        dbContext.Courses.Update(course);
        dbContext.SaveChanges();
    }
}