using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Command.CreatePlannedCourseSessionDiscontinuity;

public class CreatePlannedCourseSessionDiscontinuityCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid Id , bool discontinuity)
    {

        var sessions = dbContext.PlannedCourseSessions
            .Include(student => student.plannedCourseStudents)
            .FirstOrDefault(s => s.Id == Id);

        if(sessions is null)
            throw new Exception("Session is null !!!!!!!");
        
        foreach(var student in sessions.plannedCourseStudents)
        {
            var discontinuityParam = PlannedCourseSessionDiscontinuity.Create(
                priceParam:student.price,
                discontinuityParam : discontinuity ,
                plannedCourseStudentIdParam : student.Id ,
                plannedCourseSessionIdParam : sessions.Id
            );
            dbContext.PlannedCourseSessionDiscontinuities.Add(discontinuityParam);
        }

        dbContext.SaveChanges();
    }
}