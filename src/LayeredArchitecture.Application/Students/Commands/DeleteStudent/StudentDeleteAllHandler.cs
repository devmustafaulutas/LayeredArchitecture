using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.Students.Commands.DeleteStudent;

public class StudentDeleteAllHandler(ILayeredArchitectureDbContext dbContext)
{
    public void Handle()
    {
        var students = dbContext.Students.ToList();
        dbContext.Students.RemoveRange(students);
        dbContext.SaveChanges();
    }
}