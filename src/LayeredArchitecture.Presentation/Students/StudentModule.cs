using LayeredArchitecture.Application.Students.Commands.CreateStudent;
using LayeredArchitecture.Application.Students.Commands.UpdateStudent;
using LayeredArchitecture.Application.Students.Queries.GetAllStudents;
using LayeredArchitecture.Application.Students.Commands.DeleteStudent;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace LayeredArchitecture.WebApi.Students;

public static class StudentModule 
{
    public static void AddStudentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/students")
                        .WithTags("Students");

        group.MapGet("/" , async(IMessageBus bus)=>
        {
            var result = await bus.InvokeAsync<List<StudentCommand>>(new GetAllStudentsQuery());
            return Results.Ok(result);
        });
        group.MapPost("/" , async ([FromBody] StudentCreateCommand command ,IMessageBus bus) => 
        {
            var result = await bus.InvokeAsync<Guid>(command);
            return Results.Ok();
        });
        group.MapPut("/{studentId:guid}" ,async (Guid guid , [FromBody] StudentUpdateCommand command , IMessageBus bus) => 
        {
            var result = await bus.InvokeAsync<Guid>(command);
            return Results.NoContent();
        });
        group.MapDelete("/{studentId:guid}", async(Guid guid ,IMessageBus bus) =>
        {
            await bus.InvokeAsync<StudentDeleteCommand>(guid);
            return Results.NoContent();
        });
        group.MapDelete("/",async (IMessageBus bus)=>
        {
            await bus.InvokeAsync(new StudentDeleteAllCommand());
            return Results.NoContent();
        });
    }
}