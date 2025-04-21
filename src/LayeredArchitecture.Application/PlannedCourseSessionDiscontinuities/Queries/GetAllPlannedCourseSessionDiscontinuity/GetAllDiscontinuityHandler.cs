using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Queries.GetAllPlannedCourseSessionDiscontinuity;

public class GetAllDiscontinuityHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public GetAllDiscontinuityHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<DiscontinuityCommand>> Handle(DiscontinuityQuery query)
    {
        var discontinuities = await _dbContext.PlannedCourseSessionDiscontinuities
            .Select(discontinuity => new DiscontinuityCommand(
                discontinuity.Id ,
                discontinuity.price,
                discontinuity.discontinuity,
                discontinuity.plannedCourseStudentId ,
                discontinuity.PlannedCourseSessionId
            )).ToListAsync();
        return discontinuities;
    }
}