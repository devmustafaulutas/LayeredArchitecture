using LayeredArchitecture.Application.PlannedCourseStudents.Command.CreatePlannedCourseStudent;
using LayeredArchitecture.Application.PlannedCourseStudents.Command.DeletePlannedCourseStudent;
using LayeredArchitecture.Application.PlannedCourseStudents.Command.UpdatePlannedCourseStudent;
using LayeredArchitecture.Application.PlannedCourseStudents.Query.GetAllPlannedCourseStudentsQuery;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.WebApi.PlannedCourseStudents;

public static class PlannedCourseStudentModule 
{
    public static void AddPlannedCourseStudentsEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/plannedCourseStudent")
                        .WithTags("PlannedCourseStudent");

        group.MapGet("/" , (GetAllPlannedCourseStudentQuery query )=>
        {
            var result = query.Handle();
            return Results.Ok(result); 
        });
        group.MapPost("/",([FromBody] CreatePlannedCourseStudentDto createplannedCourseDto , CreatePlannedCourseStudentCommand command) =>
        {
            var result = command.Handle(createplannedCourseDto);
            return Results.Ok(result);
        });
        group.MapPut("/{plannedCourseStudentId:guid}", (Guid plannedCourseStudentId , [FromBody] UpdatePlannedCourseStudentDto updatePlannedCourseStudentDto ,UpdatePlannedCourseStudentCommand command) =>
        {
            command.Handle(plannedCourseStudentId ,updatePlannedCourseStudentDto);
            return Results.NoContent();
        });
        group.MapDelete("/{plannedCourseStudentId:guid}",(Guid plannedCourseStudentId , DeleteOnePlannedCourseStudentCommand command) =>
        {
            command.Handle(plannedCourseStudentId);
            return Results.NoContent();
        });
        group.MapDelete("/" , (DeleteAllPlannedCourseStudentsCommand command)=> 
        {
            command.Handle();
            return Results.NoContent();
        });
    }
}