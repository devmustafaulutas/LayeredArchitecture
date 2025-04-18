namespace LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Queries.GetAllPlannedCourseSessionDiscontinuity;

public record DiscontinuityCommand
(
    Guid Id ,
    decimal price ,
    bool discontinuity ,
    Guid studentId ,
    Guid sessionId
);