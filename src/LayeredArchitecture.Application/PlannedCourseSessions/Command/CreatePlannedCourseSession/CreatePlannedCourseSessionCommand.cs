using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourseSessions.Command.CreatePlannedCourseSession;
public class CreatePlannedCourseSessionCommand(ILayeredArchitectureDbContext dbContext)
{
    public static Guid Handle(CreatePlannedCourseSessionDto createPlannedCourseSessionDto)
    {
        Guid guid = Guid.NewGuid();
        return guid;
        
    }
}