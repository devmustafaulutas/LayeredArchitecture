using LayeredArchitecture.Application.PlannedCourseSessions.Query.GetAllPlannedCourseSession;
using LayeredArchitecture.Application.PlannedCourseSessions.Command.CreatePlannedCourseSession;
using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Application.PlannedCourseStudents.Command.DeletePlannedCourseStudent;
using Wolverine;
using LayeredArchitecture.Application.PlannedCourseSessions.Command.DeletePlannedCourseSession;

namespace LayeredArchitecture.WebApi.PlannedCourseSessions;

public static class PlannedCourseSessionModule
{
    public static void AddPlannedCourseSessionsEndPoints(this IEndpointRouteBuilder app)
    {
        var group =  app.MapGroup("/api/v1/plannedCourseSession")
                        .WithTags("PlannedCourseSession");

        group.MapGet("/" , async ([FromServices] IMessageBus bus) =>
        {
            var results = await bus.InvokeAsync<List<PlannedCourseSessionCommand>>(new GetAllPlannedCourseSessionQuery());
            return Results.Ok(results);
        });
        group.MapPost("/", async ([FromBody]CreatePlannedCourseSessionCommand command  ,IMessageBus bus) => 
        {
            var results = await bus.InvokeAsync<Guid>(command);
            return Results.Ok(results);
        });
        group.MapDelete("/{plannedCourseSessionId:guid}", async (Guid plannedCourseSessionId ,[FromServices] IMessageBus bus ) =>
        {
            await bus.InvokeAsync(new DeletePlannedCourseSessionCommand());
            return Results.NoContent();
        });
        group.MapDelete("/" , async([FromServices] IMessageBus bus)=>
        {
            await bus.InvokeAsync(new DeleteAllPlannedCourseSessionCommand());
            return Results.NoContent();
        });
        
    }
}