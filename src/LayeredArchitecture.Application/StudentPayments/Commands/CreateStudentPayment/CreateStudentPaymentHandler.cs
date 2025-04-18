using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.StudentPayments.Command.CreateStudentPayment;

public class CreateStudentPaymentHandler(ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(CreateStudentPaymentCommand createStudentPaymentCommand)
    {
        var student = StudentPayment.Create(createStudentPaymentCommand.amount , createStudentPaymentCommand.studentId);
        if(student is null)
            throw new Exception($"Student payment for create is null !");
        dbContext.StudentPayments.Add(student);
        dbContext.SaveChanges();
        return student.Id;
    }
}