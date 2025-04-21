using LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Command.CreatePlannedCourseSessionDiscontinuity;
using LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Queries.GetAllPlannedCourseSessionDiscontinuity;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace LayeredArchitecture.WebApi.PlannedCourseSessionDiscontinuities;

public static class DiscontinuityModule
{
    public static void AddDiscontinuityEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/discontinuity")
                        .WithTags("Discontinuity");

        group.MapGet("/" ,async ([FromServices] IMessageBus bus) =>
        {
            var result = await bus.InvokeAsync<List<DiscontinuityCommand>>(new DiscontinuityQuery());
            return Results.Ok(result);
        });
        group.MapPost("/" , async ([FromBody] DiscontinuityCommand command, [FromServices] IMessageBus bus) =>
        {
            // handler.Handle(Id , discontinuity);
            await bus.InvokeAsync<Guid>(command);
            return Results.Ok();
        });
    }
}