namespace LayeredArchitecture.Domain;

public class PlannedCourseStudent
{
    public Guid Id { get; private set; }
    public decimal price { get; private set; }
    public Guid studentId { get; private set; }
    public Student student { get; private set; }
    public PlannedCourse plannedCourse { get; private set; }
    public Guid plannedCourseId { get; private set; }
    protected PlannedCourseStudent()
    {
    }
    public static PlannedCourseStudent Create(decimal priceParam , Guid plannedCourseIdParam , Guid studentIdParam)
    {
        return new PlannedCourseStudent{
            Id = Guid.NewGuid(),
            price = priceParam,
            plannedCourseId = plannedCourseIdParam ,
            studentId = studentIdParam
        };
    }
    public void Update(decimal priceParam)
    {
        price = priceParam;
    }
}