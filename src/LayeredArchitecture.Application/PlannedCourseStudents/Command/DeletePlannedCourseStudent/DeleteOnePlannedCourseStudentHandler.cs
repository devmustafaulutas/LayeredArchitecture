using System.Threading.Tasks;
using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.DeletePlannedCourseStudent;

public class DeleteOnePlannedCourseStudentHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public DeleteOnePlannedCourseStudentHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(DeleteOnePlannedStudentCommand command)
    {
        var plannedCourseStudent = await _dbContext.PlannedCourseStudents.FindAsync(command.Id);
        if(plannedCourseStudent is null)
            throw new Exception("PlannedCourseStudent for delete action is null !");
        _dbContext.PlannedCourseStudents.Remove(plannedCourseStudent);
        await _dbContext.SaveChangesAsync();
    }
}