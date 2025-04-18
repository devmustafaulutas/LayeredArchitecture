namespace LayeredArchitecture.Application.StudentPayments.Queries.GetAllStudentPayment;
public record StudentPaymentCommand(
    Guid Id,
    Guid studentId,
    string studentName,
    decimal amount ,
    DateTime paymentDate
);