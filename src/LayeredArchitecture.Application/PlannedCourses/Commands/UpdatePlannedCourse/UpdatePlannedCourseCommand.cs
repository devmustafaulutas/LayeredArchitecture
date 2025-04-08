using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Commands.UpdatePlannedCourse;

public record UpdatePlannedCourseDto(Day day , DateTime startTime);