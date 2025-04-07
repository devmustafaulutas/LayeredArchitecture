namespace LayeredArchitecture.Domain;

public class PlannedCourseSession
{
    public Guid Id { get; set; }
    public Guid plannedCourseId { get; set; }
    public PlannedCourse plannedCourse { get; set; }
    public DateTime dateTime { get; set; }

    public ICollection<PlannedCourseSessionDiscontinuity> plannedCourseSessionDiscontinuities {get; set ;}
}