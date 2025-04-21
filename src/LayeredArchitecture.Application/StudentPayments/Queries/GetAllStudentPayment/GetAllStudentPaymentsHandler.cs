using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.StudentPayments.Queries.GetAllStudentPayment;
public class GetAllStudentPaymentsHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public GetAllStudentPaymentsHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<StudentPaymentCommand>> Handle(GetAllStudentPaymentsQuery query)
    {
        var student = await _dbContext.StudentPayments
            .Include(s => s.students)
            .Select(s => new StudentPaymentCommand(
                s.Id,
                s.StudentId,
                s.student.nameSurname,
                s.amount,
                s.paymentDate
            ))
            .ToListAsync();
        return student;
    }
}