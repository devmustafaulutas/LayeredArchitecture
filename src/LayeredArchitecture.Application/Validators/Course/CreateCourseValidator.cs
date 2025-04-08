using LayeredArchitecture.Application.Courses.Commands.CreateCourse;

namespace LayeredArchitecture.Application.Validators.Course
{
    public class CreateCourseValidator
    {
        public bool Validate(CreateCourseDto courseDto)
        {
            // Time, 15 ile 60 dakika arasında olmalı ve 15'in katı olmalı
            if (courseDto.Time >= 15 && courseDto.Time <= 60 && courseDto.Time % 15 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
