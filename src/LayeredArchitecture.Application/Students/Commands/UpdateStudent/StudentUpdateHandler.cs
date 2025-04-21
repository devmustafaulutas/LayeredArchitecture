using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
namespace LayeredArchitecture.Application.Students.Commands.UpdateStudent;

public class StudentUpdateHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public StudentUpdateHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(StudentUpdateCommand command)
    {
        var student = await _dbContext.Students.FindAsync(command.Id);
        if(student is null)
            throw new Exception("Student for update id is null");

        student.Update(command.nameSurnameParam, command.parentNameSurnameParam, command.phoneParam,
                       command.parentPhoneParam);
        _dbContext.Students.Update(student);
        await _dbContext.SaveChangesAsync();
    }
}