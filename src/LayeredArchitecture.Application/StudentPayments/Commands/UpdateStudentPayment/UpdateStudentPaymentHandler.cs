using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.StudentPayments.Queries.GetAllStudentPayment;
using LayeredArchitecture.Application.Students.Commands.DeleteStudent;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.StudentPayments.Command.UpdateStudentPayment;
public class UpdateStudentPaymentHandler(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid id , UpdateStudentPaymentCommand studentPaymentCommand) 
    {
        var sp = dbContext.StudentPayments.Find(id);
        if(sp is null)
            throw new Exception($"Student Payment for update is null !");
        sp.Update(studentPaymentCommand.amount);
        dbContext.StudentPayments.Update(sp);
        dbContext.SaveChanges();
    }
}