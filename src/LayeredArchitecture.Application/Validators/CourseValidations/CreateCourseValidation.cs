using LayeredArchitecture.Application.Courses.Commands.CreateCourse;

namespace LayeredArchitecture.Application.Validators.CourseValidations;
public class CreateCourseValidation
{
    public void Validate(CreateCourseDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new Exception("Kurs adı boş olamaz!");

        if (dto.Quota <= 0)
            throw new Exception("Kota sıfırdan büyük olmalı!");

        if (dto.Time < DateTime.MinValue.AddMinutes(15) || dto.Time > DateTime.MaxValue.AddMinutes(60))
            throw new Exception("Süre 15 ile 60 dakika arasında olmalı!");
    }
}
