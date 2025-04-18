namespace LayeredArchitecture.Application.Students.Queries.GetAllStudents;

public record StudentCommand(Guid Id , string nameSurnameParam , string parentNameSurnameParam , string phoneParam , string parentPhoneParam , decimal studentDebt);