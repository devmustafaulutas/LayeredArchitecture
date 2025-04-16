using LayeredArchitecture.Application.PlannedCourseSessions.Query.GetAllPlannedCourseSession;
using LayeredArchitecture.Application.PlannedCourseSessions.Command.CreatePlannedCourseSession;
using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Application.PlannedCourseStudents.Command.DeletePlannedCourseStudent;

namespace LayeredArchitecture.WebApi.PlannedCourseSessions;

public static class PlannedCourseSessionModule
{
    public static void AddPlannedCourseSessionsEndPoints(this IEndpointRouteBuilder app)
    {
        var group =  app.MapGroup("/api/v1/plannedCourseSession")
                        .WithTags("PlannedCourseSession");

        group.MapGet("/" , (GetAllPlannedCourseSessionQuery query) =>
        {
            var results  = query.Handle();
            return Results.Ok(results);
        });
        group.MapPost("/", ([FromBody]CreatePlannedCourseSessionDto createplannedCourseDto  , CreatePlannedCourseSessionCommand command) => 
        {
            var results = command.Handle(createplannedCourseDto);
            return Results.Ok(results);
        });
        group.MapDelete("/{plannedCourseSessionId:guid}", ([FromRoute]Guid plannedCourseSessionId , DeleteOnePlannedCourseStudentCommand command) =>
        {
            command.Handle(plannedCourseSessionId);
            return Results.NoContent();
        });
        group.MapDelete("/" , (DeleteAllPlannedCourseStudentsCommand command)=>
        {
            command.Handle();
            return Results.NoContent();
        });
        
    }
}