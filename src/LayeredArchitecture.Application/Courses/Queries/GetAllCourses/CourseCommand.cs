namespace LayeredArchitecture.Application.Courses.Queries.GetAllCourses;

public record CourseCommand(Guid Id, string Name,int Time, int Quota);