using LayeredArchitecture.Domain;
namespace LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;
public record CreatePlannedCourseCommand(Guid courseId , Day day , int startTime);