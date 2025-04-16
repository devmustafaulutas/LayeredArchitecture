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

        group.MapPost("/", ([FromBody] CreatePlannedCourseDto createplannedCourseDto, CreatePlannedCourseCommand command) =>
        {
            var result = command.Handle(createplannedCourseDto);
            return Results.Ok(result);
        });
        group.MapPut("/{plannedCourseId:guid}",([FromBody] UpdatePlannedCourseDto updatePlannedCourseDto, Guid plannedCourseId , UpdatePlannedCourseCommand command) =>
        {
           command.Handle(plannedCourseId,updatePlannedCourseDto);
           return Results.NoContent();
        });
        group.MapDelete("/{plannedCourseId:guid}",(Guid plannedCourseId , DeletePlannedCourseCommand command) =>
        {
            command.Handle(plannedCourseId);
            return Results.NoContent();
        });
    }
}