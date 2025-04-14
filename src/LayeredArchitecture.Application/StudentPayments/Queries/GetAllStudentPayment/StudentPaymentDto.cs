namespace LayeredArchitecture.Application.StudentPayments.Queries.GetAllStudentPayment;
public record StudentPaymentDto(
    Guid Id,
    Guid studentId,
    string studentName,
    decimal amount ,
    DateTime paymentDate
);