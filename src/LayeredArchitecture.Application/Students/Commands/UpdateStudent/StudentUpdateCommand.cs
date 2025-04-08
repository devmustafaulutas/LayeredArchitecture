using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
namespace LayeredArchitecture.Application.Students.Commands.UpdateStudent;

public class StudentUpdateCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid guid,StudentUpdateDto studentDto)
    {
        var student = dbContext.Students.Find(guid);
        if(student is null)
            throw new Exception("Student for update id is null");

        student.Update(studentDto.nameSurnameParam, studentDto.parentNameSurnameParam, studentDto.phoneParam,
                       studentDto.parentPhoneParam);
        dbContext.Students.Update(student);
        dbContext.SaveChanges();
    }
}