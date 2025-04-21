using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.StudentPayments.Command.DeleteStudentPayment;
public class DeleteAllStudentPaymentHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public DeleteAllStudentPaymentHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task  Handle()
    {
        var sp = await _dbContext.StudentPayments.ToListAsync();
        if(sp is null)
            throw new Exception($"Student Payments for delete all is null !");
        _dbContext.StudentPayments.RemoveRange(sp);
        await _dbContext.SaveChangesAsync();
    }
}