namespace LayeredArchitecture.Domain;
public class PlannedCourseSessionDiscontinuity
{
    public int Id { get; set; }
    public decimal price { get; set; }
    public bool discontinuity { get; set; }
    public int StudentId { get; set; }
    public Student student { get; set; }
    public int PlannedCourseSessionId { get; set; }
    public PlannedCourseSession plannedCourseSession { get; set; }

}