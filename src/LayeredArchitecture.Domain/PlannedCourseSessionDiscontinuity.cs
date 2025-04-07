namespace LayeredArchitecture.Domain;
public class PlannedCourseSessionDiscontinuity
{
    public Guid Id { get; set; }
    public decimal price { get; set; }
    public bool discontinuity { get; set; }
    public Guid StudentId { get; set; }
    public Student student { get; set; }
    public Guid PlannedCourseSessionId { get; set; }
    public PlannedCourseSession plannedCourseSession { get; set; }

}