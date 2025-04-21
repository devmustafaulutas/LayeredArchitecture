using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.Courses.Commands.DeleteCourse;

public class DeleteCourseHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public DeleteCourseHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public async Task Handle(DeleteCourseCommand command)
    {
        var entity = await _dbContext.Courses.FindAsync(command.Id);
        if(entity is null)
        {
            throw new Exception("Course not found");
        }
        _dbContext.Courses.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}