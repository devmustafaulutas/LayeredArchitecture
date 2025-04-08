using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.Students.Commands.CreateStudent;

public class StudentCreateCommand  (ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(StudentCreateDto studentCreateDto)
    {
        var student  = Student.Create(studentCreateDto.nameSurname ,studentCreateDto.parentNameSurname , studentCreateDto.phone , studentCreateDto.parentPhone);
        dbContext.students.Add(student);
        dbContext.SaveChanges();
        return student.Id;
    }
}