using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Queries;

public record PlannedCourseDto(Guid courseId , Day day , int startTime , string courseName , int courseQuota , int courseTime);

