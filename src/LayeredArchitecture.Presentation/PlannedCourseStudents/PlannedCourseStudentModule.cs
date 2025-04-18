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
        group.MapPost("/",([FromBody] CreatePlannedCourseStudentCommand createplannedCourseCommand , CreatePlannedCourseStudentHandler handler) =>
        {
            var result = handler.Handle(createplannedCourseCommand);
            return Results.Ok(result);
        });
        group.MapPut("/{plannedCourseStudentId:guid}", (Guid plannedCourseStudentId , [FromBody] UpdatePlannedCourseStudentCommand updatePlannedCourseStudentCommand ,UpdatePlannedCourseStudentHandler handler) =>
        {
            handler.Handle(plannedCourseStudentId ,updatePlannedCourseStudentCommand);
            return Results.NoContent();
        });
        group.MapDelete("/{plannedCourseStudentId:guid}",(Guid plannedCourseStudentId , DeleteOnePlannedCourseStudentHandler handler) =>
        {
            handler.Handle(plannedCourseStudentId);
            return Results.NoContent();
        });
        group.MapDelete("/" , (DeleteAllPlannedCourseStudentsHandler handler)=> 
        {
            handler.Handle();
            return Results.NoContent();
        });
    }
}