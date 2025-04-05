namespace LayeredArchitecture.Domain;

public enum Day
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public class PlannedCourse
{
    public Guid Id { get; set; }
    public Day DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }


    protected PlannedCourse()
    {
    }
    public PlannedCourse Create( Course course , Day day , TimeOnly startTime)
    {
        return new PlannedCourse
        {
            Id = Guid.NewGuid(),
            CourseId = course.Id,
            DayOfWeek = day,
            StartTime = startTime
        };
    }
}

