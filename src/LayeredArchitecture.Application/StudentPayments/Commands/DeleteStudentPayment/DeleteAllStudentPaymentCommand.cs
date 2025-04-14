using LayeredArchitecture.Application.Abstractions.Database;

namespace LayeredArchitecture.Application.StudentPayments.Command.DeleteStudentPayment;
public class DeleteAllStudentPaymentCommand(ILayeredArchitectureDbContext dbContext)
{
    public void  Handle()
    {
        var sp = dbContext.StudentPayments.ToList();
        if(sp is null)
            throw new Exception($"Student Payments for delete all is null !");
        dbContext.StudentPayments.RemoveRange(sp);
        dbContext.SaveChanges();
    }
}