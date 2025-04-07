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
    public Guid Id { get; private set; }
    public Day DayOfWeek { get; private set; }
    public int StartTime { get; private set; }
    public Guid CourseId { get; private set; }
    public Course Course { get; private set; }


    protected PlannedCourse()
    {
    }
    public static PlannedCourse Create( Guid courseId , Day day , int startTime)
    {
        return new PlannedCourse
        {
            Id = Guid.NewGuid(),
            CourseId = courseId,
            DayOfWeek = day,
            StartTime = startTime
        };
    }
    public void Update( Day day , int startTime)
    {
        DayOfWeek = day;
        StartTime = startTime;
    }

}

