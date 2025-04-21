using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.PlannedCourseStudents.Query.GetAllPlannedCourseStudents;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourseStudents.Query.GetAllPlannedCourseStudentsQuery;
public class GetAllPlannedCourseStudentHandler (ILayeredArchitectureDbContext dbContext)
{
    public async Task<List<PlannedCourseStudentCommand>> Handle(GetAllPlannedCourseStudentQuery query)
    {
        var plannedCourseStudent = await dbContext.PlannedCourseStudents
            .Include(s => s.student)
            .Select(pcs => new PlannedCourseStudentCommand
            (
                pcs.Id,
                pcs.price,
                pcs.student.nameSurname
            ))
            .ToListAsync();
        return plannedCourseStudent;
    }
}   