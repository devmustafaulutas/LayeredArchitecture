using LayeredArchitecture.Application.Abstractions.Database;

using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Query.GetAllPlannedCourseStudentsQuery;
public class GetAllPlannedCourseStudentQuery (ILayeredArchitectureDbContext dbContext)
{
    public List<PlannedCourseStudentCommand> Handle()
    {
        var plannedCourseStudent = dbContext.PlannedCourseStudents
            .Include(s => s.student)
            .Select(pcs => new PlannedCourseStudentCommand
            (
                pcs.Id,
                pcs.price,
                pcs.student.nameSurname
            ))
            .ToList();
        return plannedCourseStudent;
    }
}   