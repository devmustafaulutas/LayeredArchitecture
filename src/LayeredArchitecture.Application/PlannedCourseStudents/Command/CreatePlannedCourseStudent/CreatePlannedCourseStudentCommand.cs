namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.CreatePlannedCourseStudent;
public record CreatePlannedCourseStudentCommand(
    decimal price,
    Guid plannedCourseId,
    Guid studentId
);