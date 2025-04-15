namespace LayeredArchitecture.Domain;

public class PlannedCourseSession
{
    public Guid Id { get; private set; }
    public DateOnly date { get; private set; }
    public Guid plannedCourseId { get; private set; }
    public PlannedCourse plannedCourse { get; private set; }
    
    

    protected PlannedCourseSession()
    {
    }
    public static PlannedCourseSession Create(Guid plannedCourseIdParam , DateOnly dateParam)
    {

        return new PlannedCourseSession
        {
            Id = Guid.NewGuid(),
            plannedCourseId = plannedCourseIdParam,
            date =  dateParam
        };
    }
    public void Update(DateOnly dateParam)
    {
        date = dateParam;
    }
    public ICollection<PlannedCourseSessionDiscontinuity> plannedCourseSessionDiscontinuities {get; set ;}
    
}