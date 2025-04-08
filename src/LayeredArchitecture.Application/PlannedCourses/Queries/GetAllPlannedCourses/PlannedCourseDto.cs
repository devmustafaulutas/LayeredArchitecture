using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Queries;

public record PlannedCourseDto(Guid courseId , Day day , DateTime startTime , string courseName , int courseQuota , DateTime courseTime);

