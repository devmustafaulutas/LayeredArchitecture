namespace LayeredArchitecture.Application.PlannedCourseSessions.Command.CreatePlannedCourseSession;

public record CreatePlannedCourseSessionDto(
    Guid plannedCourseSessionId,
    DateOnly date 
);