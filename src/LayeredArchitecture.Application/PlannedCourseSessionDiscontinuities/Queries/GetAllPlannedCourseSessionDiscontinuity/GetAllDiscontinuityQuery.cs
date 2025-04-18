using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Queries.GetAllPlannedCourseSessionDiscontinuity;

public class GetAllDiscontinuityQuery(ILayeredArchitectureDbContext dbContext)
{
    public List<DiscontinuityCommand> Handle()
    {
        var discontinuities = dbContext.PlannedCourseSessionDiscontinuities
            .Select(discontinuity => new DiscontinuityCommand(
                discontinuity.Id ,
                discontinuity.price,
                discontinuity.discontinuity,
                discontinuity.plannedCourseStudentId ,
                discontinuity.PlannedCourseSessionId
            )).ToList();
        return discontinuities;
    }
}