using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.CreatePlannedCourseStudent;
public class CreatePlannedCourseStudentCommand (ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(CreatePlannedCourseStudentDto createPlannedCourseStudentDto)
    {
        var plannedCourseStudent = PlannedCourseStudent.Create(createPlannedCourseStudentDto.price , createPlannedCourseStudentDto.plannedCourseId , createPlannedCourseStudentDto.studentId);
        dbContext.PlannedCourseStudents.Add(plannedCourseStudent);
        dbContext.SaveChanges();
        return plannedCourseStudent.Id;
    }
}