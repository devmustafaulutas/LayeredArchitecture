using LayeredArchitecture.Domain;
namespace LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;
public record CreatePlannedCourseDto(Guid courseId , Day day , DateTime startTime);