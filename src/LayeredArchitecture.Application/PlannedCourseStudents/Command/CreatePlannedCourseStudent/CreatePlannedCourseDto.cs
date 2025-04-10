namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.CreatePlannedCourseStudent;
public record CreatePlannedCourseStudentDto(
    decimal price,
    Guid plannedCourseId,
    Guid studentId
);