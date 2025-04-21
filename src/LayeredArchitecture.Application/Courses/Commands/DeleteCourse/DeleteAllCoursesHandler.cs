using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.Courses.Queries.GetAllCourses;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.Courses.Commands.DeleteCourse;
public class DeleteAllCoursesHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public DeleteAllCoursesHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(DeleteAllCourseCommand command)
    {
        var allCourses = await _dbContext.Courses.ToListAsync();
        _dbContext.Courses.RemoveRange(allCourses);
        await _dbContext.SaveChangesAsync();
    }
}