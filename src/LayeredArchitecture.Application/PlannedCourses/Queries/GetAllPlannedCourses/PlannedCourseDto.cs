using LayeredArchitecture.Domain;
using LayeredArchitecture.Application.Helpers;

namespace LayeredArchitecture.Application.PlannedCourses.Queries;

public record PlannedCourseDto(
    Guid Id,
    Guid CourseId,
    string CourseName,
    int Quota
)
{
    private Day DayOfWeekRaw { get; init; }
    private int StartTimeRaw { get; init; }

    public string DayOfWeek => DayOfWeekRaw.ToString();
    public string StartTime => FormatHelper.FormatTime(StartTimeRaw);
    public string EndTime => FormatHelper.FormatTime(StartTimeRaw + 60);

    public PlannedCourseDto(
        Guid id,
        Guid courseId,
        string courseName,
        Day dayOfWeek,
        int startTime,
        int quota
    ) : this(id, courseId, courseName, quota)
    {
        DayOfWeekRaw = dayOfWeek;
        StartTimeRaw = startTime;
    }
}
