using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.DeletePlannedCourseStudent;
public class DeleteAllPlannedCourseStudentsCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle()
    {
        var plannedCourseStudents = dbContext.PlannedCourseStudents.ToList();
        dbContext.PlannedCourseStudents.RemoveRange(plannedCourseStudents);
        dbContext.SaveChanges();
    }
}