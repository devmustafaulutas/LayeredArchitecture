namespace LayeredArchitecture.Application.Students.Queries.GetAllStudents;

public record StudentDto(Guid Id , string nameSurnameParam , string parentNameSurnameParam , string phoneParam , string parentPhoneParam , decimal studentDebt);