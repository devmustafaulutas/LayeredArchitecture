using Wolverine;

namespace LayeredArchitecture.Application.Courses.Commands.CreateCourse;

public record CreateCourseCommand(string Name,int Time,int Quota);