using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.Courses.Commands.UpdateCourse;

public class UpdateCourseCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid courseId, UpdateCourseDto courseDto)
    {
        var course = dbContext.Courses.Find(courseId);
        
        course.Update(courseDto.Name, courseDto.Quota,courseDto.Time);

        if(courseDto.Time % 15 != 0)
        {
            throw new Exception("Time must be a multiple of 15");
        }
        dbContext.Courses.Update(course);
        
        dbContext.SaveChanges();
    }
}