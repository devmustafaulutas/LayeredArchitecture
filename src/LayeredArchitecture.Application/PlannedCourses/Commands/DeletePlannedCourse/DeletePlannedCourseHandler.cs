using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.PlannedCourses.Queries;

namespace LayeredArchitecture.Application.PlannedCourses.Commands.DeletePlannedCourse;

public class DeletePlannedCourseHandler(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid guid)
    {
        var entity = dbContext.PlannedCourses.Find(guid);
        if(entity is null)
            throw new Exception("planned course id null");
        dbContext.PlannedCourses.Remove(entity);
        dbContext.SaveChanges();
    }
}