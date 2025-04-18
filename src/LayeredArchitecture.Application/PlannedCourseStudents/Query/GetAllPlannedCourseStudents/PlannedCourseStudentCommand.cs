namespace LayeredArchitecture.Application.PlannedCourseStudents.Query.GetAllPlannedCourseStudentsQuery;
public record PlannedCourseStudentCommand
(
    Guid Id,
    decimal price,
    string studentNameSurName
);