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
        group.MapPost("/" , ([FromBody] StudentCreateCommand studentCreateCommand , StudentCreateHandler handler) => 
        {
            handler.Handle(studentCreateCommand);
            return Results.Ok();
        });
        group.MapPut("/{studentId:guid}" , (Guid guid , [FromBody] StudentUpdateCommand studentUpdateCommand , StudentUpdateHandler handler) => 
        {
            handler.Handle(guid , studentUpdateCommand);
            return Results.NoContent();
        });
        group.MapDelete("/{studentId:guid}",(Guid guid , StudentDeleteHandler handler) =>
        {
            handler.Handle(guid);
            return Results.NoContent();
        });
        group.MapDelete("/",(StudentDeleteAllHandler handler)=>
        {
            handler.Handle();
            return Results.NoContent();
        });
    }
}