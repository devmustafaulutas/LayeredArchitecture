using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.UpdatePlannedCourseStudent;
public class UpdatePlannedCourseStudentHandler (ILayeredArchitectureDbContext dbContext)
{
    public async Task<Guid> Handle( UpdatePlannedCourseStudentCommand command) 
    {
        var plannedCourseStudent = await dbContext.PlannedCourseStudents.FindAsync(command.Id);
        if(plannedCourseStudent is null)
            throw new Exception($"PlannedCourseStudent is null with id : {command.Id}");
        plannedCourseStudent.Update(command.price);
        await dbContext.SaveChangesAsync();
        return command.Id;
    }
}
