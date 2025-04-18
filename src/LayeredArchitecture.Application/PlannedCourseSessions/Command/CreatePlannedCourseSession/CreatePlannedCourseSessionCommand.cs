namespace LayeredArchitecture.Application.PlannedCourseSessions.Command.CreatePlannedCourseSession;

public record CreatePlannedCourseSessionCommand(
    Guid plannedCourseId,
    DateOnly date 
);