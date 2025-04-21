using LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Commands.UpdatePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Commands.DeletePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Queries;
using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Application.Courses.Commands.CreateCourse;
using FluentValidation;

namespace LayeredArchitecture.WebApi.PlannedCourses;

public static class PlannedCourseModule
{
    public static void AddPlannedCoursesEndpoints(this IEndpointRouteBuilder app )
    {
        var group = app.MapGroup("/api/v1/plannedCourses")
                            .WithTags("PlannedCourse");

        group.MapGet("/" , (GetAllPlannedCoursesQuery query) =>
        {
            var result = query.Handle();
            return Results.Ok(result);
        });

        group.MapPost("/", async ([FromBody] CreatePlannedCourseCommand command, CreatePlannedCourseHandler handler) =>
        {
            var result = await handler.Handle(command);
            return Results.Ok(result);
        });
        group.MapPut("/{plannedCourseId:guid}",async (Guid plannedCourseId , [FromBody] UpdatePlannedCourseCommand command , UpdatePlannedCourseHandler handler) =>
        {
            await handler.Handle(plannedCourseId,command);
            return Results.NoContent();
        });
        group.MapDelete("/{plannedCourseId:guid}",(Guid plannedCourseId , DeletePlannedCourseHandler handler) =>
        {
            handler.Handle(plannedCourseId);
            return Results.NoContent();
        });
    }
}