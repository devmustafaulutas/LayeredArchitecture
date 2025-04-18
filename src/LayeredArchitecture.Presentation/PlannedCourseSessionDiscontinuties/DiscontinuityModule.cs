using LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Command.CreatePlannedCourseSessionDiscontinuity;
using LayeredArchitecture.Application.PlannedCourseSessionDiscontinuities.Queries.GetAllPlannedCourseSessionDiscontinuity;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.WebApi.PlannedCourseSessionDiscontinuities;

public static class DiscontinuityModule
{
    public static void AddDiscontinuityEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/discontinuity")
                        .WithTags("Discontinuity");

        group.MapGet("/" , (GetAllDiscontinuityQuery query) =>
        {
            var result = query.Handle();
            return Results.Ok(result);
        });
        group.MapPost("/" , ([FromBody] bool discontinuity , Guid Id , CreatePlannedCourseSessionDiscontinuityHandler handler) =>
        {
            handler.Handle(Id , discontinuity);
            return Results.Ok();
        });
    }
}