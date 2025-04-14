using LayeredArchitecture.Application.PlannedCourseSessions.Query.GetAllPlannedCourseSession;
using LayeredArchitecture.Application.PlannedCourseSessions.Command.CreatePlannedCourseSession;
using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Application.PlannedCourseStudents.Command.DeletePlannedCourseStudent;

namespace LayeredArchitecture.WebApi.PlannedCourseSessions;

public static class PlannedCourseSessionModule
{
    public static void AddPlannedCourseSessionsEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/plannedCourseSession" , (GetAllPlannedCourseSessionQuery query) =>
        {
            var results  = query.Handle();
            return Results.Ok(results);
        });
        app.MapPost("/plannedCourseSession", ([FromBody]CreatePlannedCourseSessionDto createplannedCourseDto  , CreatePlannedCourseSessionCommand command) => 
        {
            var results = command.Handle(createplannedCourseDto);
            return Results.Ok(results);
        });
        app.MapDelete("/plannedCourseSession/{plannedCourseSessionId:guid}", ([FromRoute]Guid plannedCourseSessionId , DeleteOnePlannedCourseStudentCommand command) =>
        {
            command.Handle(plannedCourseSessionId);
            return Results.NoContent();
        });
        app.MapDelete("/plannedCourseSession" , (DeleteAllPlannedCourseStudentsCommand command)=>
        {
            command.Handle();
            return Results.NoContent();
        });
        
    }
}