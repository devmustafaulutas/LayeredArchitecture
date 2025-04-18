using LayeredArchitecture.Application.Courses.Commands.CreateCourse;
using LayeredArchitecture.Application.Courses.Queries.GetAllCourses;
using LayeredArchitecture.Application.Courses.Commands.UpdateCourse;
using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Application.Courses.Commands.DeleteCourse;
using FluentValidation.Internal;
using Wolverine;

namespace LayeredArchitecture.WebApi.Courses;

public static class CoursesModule
{
    public static void AddCoursesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/courses")
                    .WithTags("Courses");


        group.MapGet("/", (GetAllCoursesQuery query) =>
        {
            var result = query.Handle();
            return Results.Ok(result);
        });

        group.MapPost("/", async ([FromBody] CreateCourseCommand command ,[FromServices] CreateCourseHandler handler) =>
        {
            var result = await handler.Handle(command);
            return Results.Ok(result);
        });

        group.MapPut("/{courseId:guid}", (Guid courseId, [FromBody] UpdateCourseCommand courseCommand, UpdateCourseHandler handler) => {
            handler.Handle(courseId, courseCommand);

            return Results.NoContent();
        });
        group.MapDelete("/{courseId:guid}" ,(Guid courseId , DeleteCourseHandler handler) =>{
            handler.Handle(courseId);

            return Results.NoContent();
        });
        group.MapDelete("/" , (DeleteAllCoursesHandler handler)=> 
        {            
            handler.Handle();
            return Results.NoContent(); 
        });
    }
}

