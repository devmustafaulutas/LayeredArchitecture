using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.Courses.Commands.DeleteCourse;

public class DeleteCourseCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid courseId)
    {
        var entity = dbContext.Courses.Find(courseId);
        if(entity is null)
        {
            throw new Exception("Course not found");
        }
        dbContext.Courses.Remove(entity);
        dbContext.SaveChanges();
    }
}