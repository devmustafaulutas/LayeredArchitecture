using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Commands.UpdatePlannedCourse;

public record UpdatePlannedCourseCommand(Guid  plannedCourseId ,Day day , int startTime);