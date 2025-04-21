using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.DeletePlannedCourseStudent;
public class DeleteAllPlannedCourseStudentsHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public DeleteAllPlannedCourseStudentsHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(DeleteAllPlannedCourseStudentCommand command)
    {
        var plannedCourseStudents = await _dbContext.PlannedCourseStudents.ToListAsync();
        _dbContext.PlannedCourseStudents.RemoveRange(plannedCourseStudents);
        await _dbContext.SaveChangesAsync();
    }
}