using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.PlannedCourses.Queries;

namespace LayeredArchitecture.Application.PlannedCourses.Commands.DeletePlannedCourse;

public class DeletePlannedCourseHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public DeletePlannedCourseHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(DeletePlannedCourseCommand command)
    {
        var entity = await _dbContext.PlannedCourses.FindAsync(command.Id);
        if(entity is null)
            throw new Exception("planned course id null");
        _dbContext.PlannedCourses.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}