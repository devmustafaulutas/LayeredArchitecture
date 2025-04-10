using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.DeletePlannedCourseStudent;

public class DeleteOnePlannedCourseStudentCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid Id)
    {
        var plannedCourseStudent = dbContext.PlannedCourseStudents.Find(Id);
        if(plannedCourseStudent is null)
            throw new Exception("PlannedCourseStudent for delete action is null !");
        dbContext.PlannedCourseStudents.Remove(plannedCourseStudent);
        dbContext.SaveChanges();
    }
}