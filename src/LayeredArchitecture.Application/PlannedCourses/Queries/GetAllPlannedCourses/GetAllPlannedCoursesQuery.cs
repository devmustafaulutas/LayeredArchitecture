using System.Numerics;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.PlannedCourses.Queries;

public class GetAllPlannedCoursesQuery(ILayeredArchitectureDbContext dbContext)
{
    public List<PlannedCourseDto> Handle()
    {
        return dbContext.PlannedCourses
            .Select (plannedCourse => new PlannedCourseDto(plannedCourse.CourseId ,plannedCourse.DayOfWeek, plannedCourse.StartTime , plannedCourse.Course.Name  , plannedCourse.Course.Quota , plannedCourse.Course.Time))
            .ToList();
    }
}