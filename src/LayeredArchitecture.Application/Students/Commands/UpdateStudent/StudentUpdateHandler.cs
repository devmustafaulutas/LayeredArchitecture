using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
namespace LayeredArchitecture.Application.Students.Commands.UpdateStudent;

public class StudentUpdateHandler(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid guid,StudentUpdateCommand studentCommand)
    {
        var student = dbContext.Students.Find(guid);
        if(student is null)
            throw new Exception("Student for update id is null");

        student.Update(studentCommand.nameSurnameParam, studentCommand.parentNameSurnameParam, studentCommand.phoneParam,
                       studentCommand.parentPhoneParam);
        dbContext.Students.Update(student);
        dbContext.SaveChanges();
    }
}