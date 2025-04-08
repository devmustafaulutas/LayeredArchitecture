using LayeredArchitecture.Application.Courses.Commands.UpdateCourse;

namespace LayeredArchitecture.Application.Validators.Course;
public class UpdateCourseValidator()
{
    public bool Validate(UpdateCourseDto courseDto)
    {
        return courseDto.Time >= 15 || courseDto.Time <=60 || courseDto.Time % 15 == 0;
    }
}