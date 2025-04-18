namespace LayeredArchitecture.Application.StudentPayments.Command.CreateStudentPayment;
public record CreateStudentPaymentCommand(
    Guid studentId ,
    decimal amount 
);