using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.Students.Commands.CreateStudent;

public class StudentCreateHandler 
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public StudentCreateHandler (ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> Handle(StudentCreateCommand studentCreateCommand)
    {
        var student  = Student.Create(studentCreateCommand.nameSurname ,studentCreateCommand.parentNameSurname , studentCreateCommand.phone , studentCreateCommand.parentPhone);
        await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();
        return student.Id;
    }
}