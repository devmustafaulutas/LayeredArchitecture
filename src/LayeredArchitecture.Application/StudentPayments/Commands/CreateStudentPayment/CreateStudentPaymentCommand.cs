using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.StudentPayments.Command.CreateStudentPayment;

public class CreateStudentPaymentCommand(ILayeredArchitectureDbContext dbContext)
{
    public Guid Handle(CreateStudentPaymentDto createStudentPaymentDto)
    {
        var student = StudentPayment.Create(createStudentPaymentDto.amount , createStudentPaymentDto.paymentDate , createStudentPaymentDto.studentId);
        if(student is null)
            throw new Exception($"Student payment for create is null !");
        dbContext.StudentPayments.Add(student);
        dbContext.SaveChanges();
        return student.Id;
    }
}