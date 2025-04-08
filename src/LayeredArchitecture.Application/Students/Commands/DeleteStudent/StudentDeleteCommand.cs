using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.Students.Commands.DeleteStudent;

public class StudentDeleteCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid id)
    {
        var entity = dbContext.Students.Find(id);
        if(entity is null)
            throw new Exception("Student id for delete is null !");
        dbContext.Students.Remove(entity);
        dbContext.SaveChanges();
    }
}