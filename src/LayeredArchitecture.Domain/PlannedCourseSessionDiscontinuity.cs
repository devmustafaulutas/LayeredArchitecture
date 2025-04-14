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
    public static PlannedCourseSessionDiscontinuity Create(decimal priceParam , bool discontinuityParam ,Guid plannedCourseStudentIdParam , Guid plannedCourseSessionIdParam)
    {
        return new PlannedCourseSessionDiscontinuity{
            Id = Guid.NewGuid(),
            price = priceParam ,
            discontinuity = discontinuityParam ,
            plannedCourseStudentId = plannedCourseSessionIdParam ,
            PlannedCourseSessionId = plannedCourseSessionIdParam
        };
    }
}