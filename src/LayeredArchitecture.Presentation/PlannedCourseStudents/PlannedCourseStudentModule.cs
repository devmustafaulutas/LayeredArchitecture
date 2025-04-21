using LayeredArchitecture.Application.PlannedCourseStudents.Command.CreatePlannedCourseStudent;
using LayeredArchitecture.Application.PlannedCourseStudents.Command.DeletePlannedCourseStudent;
using LayeredArchitecture.Application.PlannedCourseStudents.Command.UpdatePlannedCourseStudent;
using LayeredArchitecture.Application.PlannedCourseStudents.Query.GetAllPlannedCourseStudents;
using LayeredArchitecture.Application.PlannedCourseStudents.Query.GetAllPlannedCourseStudentsQuery;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace LayeredArchitecture.WebApi.PlannedCourseStudents;

public static class PlannedCourseStudentModule 
{
    public static void AddPlannedCourseStudentsEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/plannedCourseStudent")
                        .WithTags("PlannedCourseStudent");

        group.MapGet("/" , async (IMessageBus bus ) =>
        {
            var result = await bus.InvokeAsync<List<PlannedCourseStudentCommand>>(new GetAllPlannedCourseStudentQuery());
            return Results.Ok(result); 
        });
        group.MapPost("/", async ([FromBody] CreatePlannedCourseStudentCommand command ,IMessageBus bus) =>
        {
            var result = await bus.InvokeAsync<Guid>(command);
            return Results.Ok(result);
        });
        group.MapPut("/{plannedCourseStudentId:guid}",async (Guid plannedCourseStudentId , [FromBody] UpdatePlannedCourseStudentCommand command ,IMessageBus bus) =>
        {
            var result = await bus.InvokeAsync<Guid>(command);
            return Results.Ok(result);
        });
        group.MapDelete("/{plannedCourseStudentId:guid}", async(Guid plannedCourseStudentId , IMessageBus bus) =>
        {
            await bus.InvokeAsync<DeleteAllPlannedCourseStudentCommand>(plannedCourseStudentId);
            return Results.NoContent();
        });
        group.MapDelete("/" , async (IMessageBus bus)=> 
        {
            await bus.InvokeAsync(new DeleteAllPlannedCourseStudentCommand());
            return Results.NoContent();
        });
    }
}