using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Queries.GetAllPlannedCourseSessionDiscontinuity;

public class GetAllDiscontinuityQuery(ILayeredArchitectureDbContext dbContext)
{
    public List<DiscontinuityDto> Handle()
    {
        var discontinuities = dbContext.PlannedCourseSessionDiscontinuities
            .Select(discontinuity => new DiscontinuityDto(
                discontinuity.Id ,
                discontinuity.price,
                discontinuity.discontinuity,
                discontinuity.plannedCourseStudentId ,
                discontinuity.PlannedCourseSessionId
            )).ToList();
        return discontinuities;
    }
}