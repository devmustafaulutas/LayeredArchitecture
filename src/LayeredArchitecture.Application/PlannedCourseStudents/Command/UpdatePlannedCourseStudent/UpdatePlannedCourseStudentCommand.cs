using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.UpdatePlannedCourseStudent;
public class UpdatePlannedCourseStudentCommand (ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(Guid Id , UpdatePlannedCourseStudentDto updatePlannedCourseStudentDto) 
    {
        var plannedCourseStudent = dbContext.PlannedCourseStudents.Find(Id);
        if(plannedCourseStudent is null)
            throw new Exception($"PlannedCourseStudent is null with id : {Id}");
        plannedCourseStudent.Update(updatePlannedCourseStudentDto.price);
        dbContext.SaveChanges();
        return Id;
    }
}
