namespace LayeredArchitecture.Domain;

public class PlannedCourseSession
{
    public int Id { get; set; }
    public int plannedCourseId { get; set; }
    public PlannedCourse plannedCourse { get; set; }
    public DateTime dateTime { get; set; }

    public ICollection<PlannedCourseSessionDiscontinuity> plannedCourseSessionDiscontinuities {get; set ;}
}