using LayeredArchitecture.Application.Abstractions.Database;
namespace LayeredArchitecture.Application.Courses.Commands.UpdateCourse;

public class UpdateCourseCommand(ILayeredArchitectureDbContext dbContext )
{
    public void Handle(Guid courseId, UpdateCourseDto courseDto)
    {
        var course = dbContext.Courses.Find(courseId);
        course.Update(courseDto.Name, courseDto.Quota,courseDto.Time);
        dbContext.Courses.Update(course);
        dbContext.SaveChanges();
    }
}