using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.Students.Commands.DeleteStudent;

public class StudentDeleteAllCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle()
    {
        var students = dbContext.Students.ToList();
        dbContext.Students.RemoveRange(students);
        dbContext.SaveChanges();
    }
}