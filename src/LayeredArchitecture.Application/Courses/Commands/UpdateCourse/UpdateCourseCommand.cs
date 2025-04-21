namespace LayeredArchitecture.Application.Courses.Commands.UpdateCourse;

public record UpdateCourseCommand(Guid Id,string Name,int Time, int Quota);