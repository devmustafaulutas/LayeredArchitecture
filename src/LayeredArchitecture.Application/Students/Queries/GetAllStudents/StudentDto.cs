namespace LayeredArchitecture.Application.Students.Queries.GetAllStudents;

public record StudentDto(Guid guid , string nameSurnameParam , string parentNameSurnameParam , string phoneParam , string parentPhoneParam);