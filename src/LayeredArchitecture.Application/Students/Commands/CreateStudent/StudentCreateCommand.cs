using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.Students.Commands.CreateStudent;

public class StudentCreateCommand  (ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(CreateStudentDto createStudentDto)
    {
        dbContext.
    }
}