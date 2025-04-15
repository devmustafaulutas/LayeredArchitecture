namespace LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Queries.GetAllPlannedCourseSessionDiscontinuity;

public record DiscontinuityDto(
    Guid Id ,
    decimal price ,
    bool discontinuity ,
    Guid studentId ,
    Guid sessionId
);