using LayeredArchitecture.Application.Courses.Commands.CreateCourse;
using LayeredArchitecture.Application.Courses.Queries.GetAllCourses;
using LayeredArchitecture.Application.Courses.Commands.UpdateCourse;
using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Application.Courses.Commands.DeleteCourse;
using Wolverine;

namespace LayeredArchitecture.WebApi.Courses;

public static class CoursesModule
{
    public static void AddCoursesEndpoints(this IEndpointRouteBuilder app )
    {
        var group = app.MapGroup("/api/v1/courses")
                    .WithTags("Courses");


        group.MapGet("/", async ([FromServices] IMessageBus bus) =>
        {
            var result = await bus.InvokeAsync<List<CourseCommand>>(new GetAllCoursesQuery());
            return Results.Ok(result);
        });


        group.MapPost("/", async ( [FromBody] CreateCourseCommand command ,[FromServices] IMessageBus bus) =>
        {
            var result = await bus.InvokeAsync<Guid>(command);
            return Results.Ok(result);
        });

        group.MapPut("/{courseId:guid}", async ([FromBody] UpdateCourseCommand command , IMessageBus bus) => {
            await bus.InvokeAsync(command);
            return Results.NoContent();
        });
        group.MapDelete("/{courseId:guid}" , async (Guid courseId , [FromServices] IMessageBus bus) =>{
            await bus.InvokeAsync(new DeleteCourseCommand(courseId));
            return Results.NoContent();
        });
        group.MapDelete("/" , async ([FromServices] IMessageBus bus)=> 
        {  
            await bus.InvokeAsync(new DeleteAllCourseCommand());
            return Results.NoContent(); 
        });
    }
}

