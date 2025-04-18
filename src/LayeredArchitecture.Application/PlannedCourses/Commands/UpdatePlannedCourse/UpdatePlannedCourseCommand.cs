using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Commands.UpdatePlannedCourse;

public record UpdatePlannedCourseCommand(Day day , int startTime);