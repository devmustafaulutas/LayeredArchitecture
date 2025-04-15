using LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Command.CreatePlannedCourseSessionDiscontinuity;
using LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Queries.GetAllPlannedCourseSessionDiscontinuity;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.WebApi.PlannedCourseSessionDiscontinuities;

public static class DiscontinuityModule
{
    public static void AddDiscontinuityEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/discontinuity" , (GetAllDiscontinuityQuery query) =>
        {
            var result = query.Handle();
            return Results.Ok(result);
        });
        app.MapPost("/discontinuity" , ([FromBody] bool discontinuity , Guid Id , CreatePlannedCourseSessionDiscontinuityCommand command) =>
        {
            command.Handle(Id , discontinuity);
            return Results.Ok();
        });
    }
}