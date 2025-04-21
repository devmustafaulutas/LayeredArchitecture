using LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Commands.UpdatePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Commands.DeletePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Queries;
using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Application.Courses.Commands.CreateCourse;
using FluentValidation;
using Wolverine;
using LayeredArchitecture.Application.PlannedCourses.Queries.GetAllPlannedCourses;

namespace LayeredArchitecture.WebApi.PlannedCourses;

public static class PlannedCourseModule
{
    public static void AddPlannedCoursesEndpoints(this IEndpointRouteBuilder app )
    {
        var group = app.MapGroup("/api/v1/plannedCourses")
                            .WithTags("PlannedCourse");

        group.MapGet("/" ,async  ([FromServices] IMessageBus bus) =>
        {
            var result = await bus.InvokeAsync<List<PlannedCourseCommand>>(new GetAllPlannedCourseQuery());
            return Results.Ok(result);
        });

        group.MapPost("/", async ([FromBody] CreatePlannedCourseCommand command, [FromServices] IMessageBus bus) =>
        {
            var result = await bus.InvokeAsync<Guid>(command);
            return Results.Ok(result);
        });
        group.MapPut("/{plannedCourseId:guid}",async ( [FromBody] UpdatePlannedCourseCommand command ,IMessageBus bus) =>
        {
            await bus.InvokeAsync(command);
            return Results.NoContent();
        });
        group.MapDelete("/{plannedCourseId:guid}",async (Guid plannedCourseId ,[FromServices] IMessageBus bus) =>
        {
            await bus.InvokeAsync(plannedCourseId);
            return Results.NoContent();
        });
    }
}