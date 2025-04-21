using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.StudentPayments.Queries.GetAllStudentPayment;
using LayeredArchitecture.Application.Students.Commands.DeleteStudent;
using LayeredArchitecture.Domain;

namespace LayeredArchitecture.Application.StudentPayments.Command.UpdateStudentPayment;
public class UpdateStudentPaymentHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public UpdateStudentPaymentHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle( UpdateStudentPaymentCommand command) 
    {
        var sp = await _dbContext.StudentPayments.FindAsync(command.Id);
        if(sp is null)
            throw new Exception($"Student Payment for update is null !");
        sp.Update(command.amount);
        _dbContext.StudentPayments.Update(sp);
        await _dbContext.SaveChangesAsync();
    }
}