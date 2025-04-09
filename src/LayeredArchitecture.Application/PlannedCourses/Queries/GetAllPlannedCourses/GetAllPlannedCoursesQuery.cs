using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.PlannedCourses.Queries;

public class GetAllPlannedCoursesQuery(ILayeredArchitectureDbContext dbContext)
{
    public List<PlannedCourseDto> Handle()
    {
        var courses = dbContext.PlannedCourses
            .Include(p => p.Course)  // Kurs bilgisiyle birlikte getiriyoruz
            .Select(p => new PlannedCourseDto(
                p.Id,
                p.CourseId,
                p.Course.Name,
                p.DayOfWeek,  // DayOfWeek enum olarak geliyor
                p.StartTime,  // Başlangıç saati (dakika cinsinden)
                p.Course.Quota  // Kotası
            ))
            .ToList();
        return courses;
    }
}