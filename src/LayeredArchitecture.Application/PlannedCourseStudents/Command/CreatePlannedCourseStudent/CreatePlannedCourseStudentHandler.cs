using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.CreatePlannedCourseStudent;
public class CreatePlannedCourseStudentHandler
 (ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(CreatePlannedCourseStudentCommand createPlannedCourseStudentCommand)
    {
        var plannedCourseStudent = PlannedCourseStudent.Create(createPlannedCourseStudentCommand.price , createPlannedCourseStudentCommand.plannedCourseId , createPlannedCourseStudentCommand.studentId);
        dbContext.PlannedCourseStudents.Add(plannedCourseStudent);
        dbContext.SaveChanges();
        return plannedCourseStudent.Id;
    }
}