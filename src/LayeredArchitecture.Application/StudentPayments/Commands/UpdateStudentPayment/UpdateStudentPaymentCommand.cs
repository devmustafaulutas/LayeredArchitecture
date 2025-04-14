using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.StudentPayments.Queries.GetAllStudentPayment;
using LayeredArchitecture.Application.Students.Commands.DeleteStudent;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.StudentPayments.Command.UpdateStudentPayment;
public class UpdateStudentPaymentCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid id , UpdateStudentPaymentDto studentPaymentDto) 
    {
        var sp = dbContext.StudentPayments.Find(id);
        if(sp is null)
            throw new Exception($"Student Payment for update is null !");
        sp.Update(studentPaymentDto.amount);
        dbContext.StudentPayments.Update(sp);
        dbContext.SaveChanges();
    }
}