using LayeredArchitecture.Domain;
using LayeredArchitecture.Application.Helpers;

namespace LayeredArchitecture.Application.PlannedCourses.Queries;

public record PlannedCourseDto(
    Guid Id, 
    Guid CourseId, 
    string CourseName, 
    Day DayOfWeek, 
    int StartTime, 
    int Quota
)
{
    public string DayOfWeekString => DayOfWeek.ToString();

    public string StartTimeFormatted => FormatHelper.FormatTime(StartTime);

    public string EndTimeFormatted => FormatHelper.FormatTime(StartTime + 60);


}
