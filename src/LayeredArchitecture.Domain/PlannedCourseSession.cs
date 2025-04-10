namespace LayeredArchitecture.Domain;

public class PlannedCourseSession
{
    public Guid Id { get; private set; }
    public Guid plannedCourseId { get; private set; }
    public PlannedCourse plannedCourse { get; private set; }
    public int dateTime { get; set; }
    protected PlannedCourseSession()
    {
        
    }
    public static PlannedCourseSession Create(Guid plannedCourseIdParam , int dateTimeParam)
    {
        return new PlannedCourseSession{
            Id = Guid.NewGuid(),
            plannedCourseId = plannedCourseIdParam,
            dateTime = dateTimeParam
        };
    }
    public void Update(int dateTimeParam)
    {
        dateTime = dateTimeParam;
    }
    public ICollection<PlannedCourseSessionDiscontinuity> plannedCourseSessionDiscontinuities {get; set ;}
}