using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.Students.Commands.CreateStudent;

public class StudentCreateHandler (ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(StudentCreateCommand studentCreateCommand)
    {
        var student  = Student.Create(studentCreateCommand.nameSurname ,studentCreateCommand.parentNameSurname , studentCreateCommand.phone , studentCreateCommand.parentPhone);
        dbContext.Students.Add(student);
        dbContext.SaveChanges();
        return student.Id;
    }
}