using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.Students.Commands.DeleteStudent;

public class StudentDeleteAllHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public StudentDeleteAllHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle()
    {
        var students =await  _dbContext.Students.ToListAsync();
        _dbContext.Students.RemoveRange(students);
        await _dbContext.SaveChangesAsync();
    }
}