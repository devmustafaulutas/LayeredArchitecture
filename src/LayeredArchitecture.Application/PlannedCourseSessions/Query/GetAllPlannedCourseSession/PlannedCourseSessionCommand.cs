using LayeredArchitecture.Domain;
namespace LayeredArchitecture.Application.PlannedCourseSessions.Query.GetAllPlannedCourseSession;
public record PlannedCourseSessionCommand(
    Guid id ,
    Guid plannedCourseId,
    string name,
    Day day,
    int startTime,
    DateOnly date 
);