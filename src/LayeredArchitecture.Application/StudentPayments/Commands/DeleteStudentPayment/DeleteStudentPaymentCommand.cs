using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.StudentPayments.Command.DeleteStudentPayment;
public class DeleteStudentPaymentCommand(ILayeredArchitectureDbContext dbContext)
{
    public void Handle(Guid id)
    {
        var delStudentPayment = dbContext.StudentPayments.Find(id);
        if(delStudentPayment is null)
            throw new Exception($"Student Payment For delete is null !");
        dbContext.StudentPayments.Remove(delStudentPayment);
        dbContext.SaveChanges();
    } 
}