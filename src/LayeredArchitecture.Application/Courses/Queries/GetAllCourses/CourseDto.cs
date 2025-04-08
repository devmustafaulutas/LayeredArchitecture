namespace LayeredArchitecture.Application.Courses.Queries.GetAllCourses;

public record CourseDto(Guid Id, string Name,DateTime Time, int Quota);