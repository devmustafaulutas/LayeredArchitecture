using LayeredArchitecture.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.StudentPayments.Queries.GetAllStudentPayment;
public class GetAllStudentPaymentsQuery(ILayeredArchitectureDbContext dbContext)
{
    public List<StudentPaymentCommand> Handle()
    {
        var student = dbContext.StudentPayments
            .Include(s => s.students)
            .Select(s => new StudentPaymentCommand(
                s.Id,
                s.StudentId,
                s.student.nameSurname,
                s.amount,
                s.paymentDate
            ))
            .ToList();
        return student;
    }
}