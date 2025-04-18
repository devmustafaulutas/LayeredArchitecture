using LayeredArchitecture.Application.Abstractions.Database;
namespace LayeredArchitecture.Application.Courses.Commands.UpdateCourse;

public class UpdateCourseHandler(ILayeredArchitectureDbContext dbContext )
{
    public void Handle(Guid courseId, UpdateCourseCommand command)
    {
        var course = dbContext.Courses.Find(courseId);
        course.Update(command.Name, command.Quota,command.Time);
        dbContext.Courses.Update(course);
        dbContext.SaveChanges();
    }
}