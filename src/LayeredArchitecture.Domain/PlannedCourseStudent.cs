namespace LayeredArchitecture.Domain;

public class PlannedCourseStudent
{
    public Guid Id { get; private set; }
    public decimal price { get; private set; }
    public Guid studentId { get; private set; }
    public Student student { get; private set; }
    public PlannedCourseSession plannedCourseSession { get; private set; }
    public Guid plannedCourseSessionId { get; private set; }
    protected PlannedCourseStudent()
    {
    }
    public static PlannedCourseStudent Create(decimal priceParam , Guid plannedCourseSessionIdParam , Guid studentIdParam)
    {
        return new PlannedCourseStudent{
            Id = Guid.NewGuid(),
            price = priceParam,
            plannedCourseSessionId = plannedCourseSessionIdParam ,
            studentId = studentIdParam
        };
    }
    public void Update(decimal priceParam)
    {
        price = priceParam;
    }
}