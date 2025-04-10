namespace LayeredArchitecture.Domain;
public class PlannedCourseSessionDiscontinuity
{
    public Guid Id { get; private set; }
    public decimal price { get; private set; }
    public bool discontinuity { get; private set; }
    public Guid plannedCourseStudentId { get; private set; }
    public PlannedCourseStudent plannedCourseStudent { get; private set; }
    public Guid PlannedCourseSessionId { get; private set; }
    public PlannedCourseSession plannedCourseSession { get; private set; }
    protected PlannedCourseSessionDiscontinuity()
    {
        
    }
}