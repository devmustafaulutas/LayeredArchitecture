using LayeredArchitecture.Application.Students.Commands.CreateStudent;
using LayeredArchitecture.Application.Students.Commands.UpdateStudent;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.WebApi.Students;

public static class StudentModule 
{
    public static void AddStudentEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPatch("/students" , ([FromBody] StudentCreateDto studentCreateDto , StudentCreateCommand command) => 
        {
            command.Handle(studentCreateDto);
            return Results.Ok();
        });
        app.MapPut("/students/{studentId:guid}" , (Guid guid , [FromBody] StudentUpdateDto studentUpdateDto , StudentUpdateCommand command) => 
        {
            command.Handle(guid , studentUpdateDto);
            return Results.NoContent();
        });
    }
}