namespace LayeredArchitecture.Application.Students.Commands.CreateStudent;

public record StudentCreateCommand(string nameSurname , string parentNameSurname , string phone , string parentPhone);