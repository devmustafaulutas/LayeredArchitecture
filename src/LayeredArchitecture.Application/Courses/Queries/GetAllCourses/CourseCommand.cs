namespace LayeredArchitecture.Application.Courses.Queries.GetAllCourses;

// public record CourseCommand(Guid Id, string Name,int Time, int Quota);
public class CourseCommand
{
    public CourseCommand(Guid ıd, string name, int time, int quota)
    {
        Id = ıd;
        Name = name;
        Time = time;
        Quota = quota;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    
    public int Time { get; set; }
    
    public int Quota { get; set; }
    
    
}