using LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Commands.UpdatePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Commands.DeletePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.WebApi.PlannedCourses;

public static class PlannedCourseModule
{
    public static void AddPlannedCoursesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/plannedCourses" , (GetAllPlannedCoursesQuery query) =>
        {
            var result = query.Handle();
            return Results.Ok(result);
        });

        app.MapPost("/plannedCourses", ([FromBody] CreatePlannedCourseDto createplannedCourseDto, CreatePlannedCourseCommand command) =>
        {
            var result = command.Handle(createplannedCourseDto);
            return Results.Ok(result);
        });
        app.MapPut("/plannedCourses/{plannedCourseId:guid}",([FromBody] UpdatePlannedCourseDto updatePlannedCourseDto, Guid plannedCourseId , UpdatePlannedCourseCommand command) =>
        {
           command.Handle(plannedCourseId,updatePlannedCourseDto);
           return Results.NoContent();
        });
        app.MapDelete("/plannedCourses/{plannedCourseId:guid}",(Guid plannedCourseId , DeletePlannedCourseCommand command) =>
        {
            command.Handle(plannedCourseId);
            return Results.NoContent();
        });
    }
}