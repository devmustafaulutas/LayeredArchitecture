using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.Courses.Queries.GetAllCourses;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.Courses.Commands.CreateCourse;

public class CreateCourseCommand(ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(CreateCourseDto courseDto)
    {
        
        if(courseDto.Time % 15 != 0)
        {
            throw new Exception("Time must be a multiple of 15");
        }
        var course = Course.Create(courseDto.Name,courseDto.Time, courseDto.Quota);

        dbContext.Courses.Add(course);
        
        dbContext.SaveChanges();

        return course.Id;
    }
}