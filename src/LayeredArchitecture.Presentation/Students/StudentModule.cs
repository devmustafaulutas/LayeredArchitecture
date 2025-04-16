using LayeredArchitecture.Application.Students.Commands.CreateStudent;
using LayeredArchitecture.Application.Students.Commands.UpdateStudent;
using LayeredArchitecture.Application.Students.Queries.GetAllStudents;
using LayeredArchitecture.Application.Students.Commands.DeleteStudent;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.WebApi.Students;

public static class StudentModule 
{
    public static void AddStudentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/students")
                        .WithTags("Students");

        group.MapGet("/" ,(GetAllStudentsQuery query)=>
        {
            var result = query.Handle();
            return Results.Ok(result);
        });
        group.MapPost("/" , ([FromBody] StudentCreateDto studentCreateDto , StudentCreateCommand command) => 
        {
            command.Handle(studentCreateDto);
            return Results.Ok();
        });
        group.MapPut("/{studentId:guid}" , (Guid guid , [FromBody] StudentUpdateDto studentUpdateDto , StudentUpdateCommand command) => 
        {
            command.Handle(guid , studentUpdateDto);
            return Results.NoContent();
        });
        group.MapDelete("/{studentId:guid}",(Guid guid , StudentDeleteCommand command) =>
        {
            command.Handle(guid);
            return Results.NoContent();
        });
        group.MapDelete("/",(StudentDeleteAllCommand command)=>
        {
            command.Handle();
            return Results.NoContent();
        });
    }
}