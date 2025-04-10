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
        app.MapGet("/plannedCourseStudent" , (GetAllPlannedCourseStudentQuery query )=>
        {
            var result = query.Handle();
            return Results.Ok(result); 
        });
        app.MapPost("/plannedCourseStudent",([FromBody] CreatePlannedCourseStudentDto createplannedCourseDto , CreatePlannedCourseStudentCommand command) =>
        {
            var result = command.Handle(createplannedCourseDto);
            return Results.Ok(result);
        });
        app.MapPut("/plannedCourseStudent/{plannedCourseStudentId:guid}", (Guid plannedCourseStudentId , [FromBody] UpdatePlannedCourseStudentDto updatePlannedCourseStudentDto ,UpdatePlannedCourseStudentCommand command) =>
        {
            command.Handle(plannedCourseStudentId ,updatePlannedCourseStudentDto);
            return Results.NoContent();
        });
        app.MapDelete("/plannedCourseStudent/{plannedCourseStudentId:guid}",(Guid plannedCourseStudentId , DeleteOnePlannedCourseStudentCommand command) =>
        {
            command.Handle(plannedCourseStudentId);
            return Results.NoContent();
        });
        app.MapDelete("/plannedCourseStudents" , (DeleteAllPlannedCourseStudentsCommand command)=> 
        {
            command.Handle();
            return Results.NoContent();
        });
    }
}