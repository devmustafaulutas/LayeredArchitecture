using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.StudentPayments.Commands.DeleteStudentPayment;

namespace LayeredArchitecture.Application.StudentPayments.Command.DeleteStudentPayment;
public class DeleteStudentPaymentHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public DeleteStudentPaymentHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(DeleteStudentPaymentCommand command)
    {
        var delStudentPayment = await _dbContext.StudentPayments.FindAsync(command.Id);
        if(delStudentPayment is null)
            throw new Exception($"Student Payment For delete is null !");
        _dbContext.StudentPayments.Remove(delStudentPayment);
        await _dbContext.SaveChangesAsync();
    } 
}