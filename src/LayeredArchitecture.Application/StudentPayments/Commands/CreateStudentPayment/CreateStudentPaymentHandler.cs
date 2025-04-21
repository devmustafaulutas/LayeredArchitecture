using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.StudentPayments.Command.CreateStudentPayment;

public class CreateStudentPaymentHandler
{
    private readonly ILayeredArchitectureDbContext _dbContext;
    public  CreateStudentPaymentHandler(ILayeredArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> Handle(CreateStudentPaymentCommand createStudentPaymentCommand)
    {
        var student = StudentPayment.Create(createStudentPaymentCommand.amount , createStudentPaymentCommand.studentId);
        if(student is null)
            throw new Exception($"Student payment for create is null !");
        await _dbContext.StudentPayments.AddAsync(student);
        await _dbContext.SaveChangesAsync();
        return student.Id;
    }
}