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
        group.MapPost("/", ([FromBody]CreatePlannedCourseSessionCommand createplannedCourseCommand  , CreatePlannedCourseSessionHandler handler) => 
        {
            var results = handler.Handle(createplannedCourseCommand);
            return Results.Ok(results);
        });
        group.MapDelete("/{plannedCourseSessionId:guid}", ([FromRoute]Guid plannedCourseSessionId , DeleteOnePlannedCourseStudentHandler handler) =>
        {
            handler.Handle(plannedCourseSessionId);
            return Results.NoContent();
        });
        group.MapDelete("/" , (DeleteAllPlannedCourseStudentsHandler handler)=>
        {
            handler.Handle();
            return Results.NoContent();
        });
        
    }
}