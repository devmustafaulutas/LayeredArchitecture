namespace LayeredArchitecture.Domain;

public class Course
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Time { get; private set; }
    public int Quota { get; private set; }

    protected Course()
    {
    }

    public static Course Create(string name, int quota , int time)
    {
        return new Course
        {
            Id = Guid.NewGuid(),
            Name = name,
            Time = time,
            Quota = quota
        };
    }

    public void Update(string name, int quota , int time)
    {
        Name = name;
        Quota = quota;
        Time = time;
    }
    public void Delete()
    {
    }
    public ICollection<PlannedCourse> PlannedCourses { get; set; }
}