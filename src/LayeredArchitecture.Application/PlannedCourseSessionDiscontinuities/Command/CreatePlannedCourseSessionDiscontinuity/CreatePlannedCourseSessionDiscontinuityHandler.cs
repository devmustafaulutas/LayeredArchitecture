using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Command.CreatePlannedCourseSessionDiscontinuity;

public class CreatePlannedCourseSessionDiscontinuityHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public CreatePlannedCourseSessionDiscontinuityHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(Guid Id , bool discontinuity)
    {

        var sessions = await  _dbContext.PlannedCourseSessions
            .Include(student => student.plannedCourse.plannedCourseStudents)
            .FirstOrDefaultAsync(s => s.Id == Id);

        if(sessions is null)
            throw new Exception("Session is null !!!!!!!");
        
        foreach(var student in sessions.plannedCourse.plannedCourseStudents)
        {
            var discontinuityParam = PlannedCourseSessionDiscontinuity.Create(
                priceParam:student.price,
                discontinuityParam : discontinuity ,
                plannedCourseStudentIdParam : student.Id ,
                plannedCourseSessionIdParam : sessions.Id
            );
            await _dbContext.PlannedCourseSessionDiscontinuities.AddAsync(discontinuityParam);
        }

        await _dbContext.SaveChangesAsync();
    }
}