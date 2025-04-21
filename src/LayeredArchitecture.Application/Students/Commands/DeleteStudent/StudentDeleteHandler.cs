using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.Students.Commands.DeleteStudent;

public class StudentDeleteHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public StudentDeleteHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(StudentDeleteCommand command)
    {
        var entity =await _dbContext.Students.FindAsync(command.Id);
        if(entity is null)
            throw new Exception("Student id for delete is null !");
        _dbContext.Students.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}