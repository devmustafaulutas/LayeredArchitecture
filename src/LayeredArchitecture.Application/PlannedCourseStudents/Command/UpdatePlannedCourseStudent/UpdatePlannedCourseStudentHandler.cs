using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.UpdatePlannedCourseStudent;
public class UpdatePlannedCourseStudentHandler (ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(Guid Id , UpdatePlannedCourseStudentCommand updatePlannedCourseStudentCommand) 
    {
        var plannedCourseStudent = dbContext.PlannedCourseStudents.Find(Id);
        if(plannedCourseStudent is null)
            throw new Exception($"PlannedCourseStudent is null with id : {Id}");
        plannedCourseStudent.Update(updatePlannedCourseStudentCommand.price);
        dbContext.SaveChanges();
        return Id;
    }
}
