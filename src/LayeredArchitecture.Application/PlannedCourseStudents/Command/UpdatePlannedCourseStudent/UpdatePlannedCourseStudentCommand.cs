namespace LayeredArchitecture.Application.PlannedCourseStudents.Command.UpdatePlannedCourseStudent;
public record UpdatePlannedCourseStudentCommand(
    Guid Id ,
    decimal price
);