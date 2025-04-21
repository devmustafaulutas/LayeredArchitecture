using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.CreatePlannedCourseStudent;
public class CreatePlannedCourseStudentHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public CreatePlannedCourseStudentHandler (ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreatePlannedCourseStudentCommand createPlannedCourseStudentCommand)
    {
        var plannedCourseStudent = PlannedCourseStudent.Create(createPlannedCourseStudentCommand.price , createPlannedCourseStudentCommand.plannedCourseId , createPlannedCourseStudentCommand.studentId);
        _dbContext.PlannedCourseStudents.Add(plannedCourseStudent);
        await _dbContext.SaveChangesAsync();
        return plannedCourseStudent.Id;
    }
}