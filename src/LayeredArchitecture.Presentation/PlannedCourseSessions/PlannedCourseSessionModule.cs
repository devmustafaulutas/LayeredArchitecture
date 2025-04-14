using LayeredArchitecture.Application.PlannedCourseSessions.Query.GetAllPlannedCourseSession;
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
    }
}