namespace LayeredArchitecture.Application.StudentPayments.Command.CreateStudentPayment;
public record CreateStudentPaymentDto(
    Guid studentId ,
    decimal amount 
);