
namespace LayeredArchitecture.Application.Students.Commands.UpdateStudent;
public record StudentUpdateCommand(Guid Id,string nameSurnameParam , string parentNameSurnameParam , string phoneParam , string parentPhoneParam);
