namespace LayeredArchitecture.Application.PlannedCourseSessions.Command.CreatePlannedCourseSession;

public record CreatePlannedCourseSessionDto(
    Guid plannedCourseId,
    DateOnly date 
);