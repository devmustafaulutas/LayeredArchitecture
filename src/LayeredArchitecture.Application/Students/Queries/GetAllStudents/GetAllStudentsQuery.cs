using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.Students.Queries.GetAllStudents;

public class GetAllStudentsQuery(ILayeredArchitectureDbContext dbContext)
{
    public List<StudentDto> Handle()
    {
        var students = dbContext.Students
        .Select(student => new StudentDto(student.Id , student.nameSurname , student.parentNameSurname , student.phone , student.parentPhone))
        .ToList();
        return students;
    }
}