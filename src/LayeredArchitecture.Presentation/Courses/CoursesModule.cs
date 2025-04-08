using LayeredArchitecture.Application.Courses.Commands.CreateCourse;
using LayeredArchitecture.Application.Courses.Queries.GetAllCourses;
using LayeredArchitecture.Application.Courses.Commands.UpdateCourse;
using Microsoft.AspNetCore.Mvc;
using LayeredArchitecture.Application.Courses.Commands.DeleteCourse;

namespace LayeredArchitecture.WebApi.Courses;

public static class CoursesModule
{
    public static void AddCoursesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/courses", (GetAllCoursesQuery query) =>
        {
            var result = query.Handle();
            
            return Results.Ok(result);
        });

        app.MapPost("/courses", ([FromBody] CreateCourseDto courseDto, CreateCourseCommand command) =>
        {
            var result = command.Handle(courseDto);

            return Results.Ok(result);
        });

        app.MapPut("/courses/{courseId:guid}", (Guid courseId, [FromBody] UpdateCourseDto courseDto, UpdateCourseCommand command) => {
            command.Handle(courseId, courseDto);

            return Results.NoContent();
        });
        app.MapDelete("/course/{courseId:guid}" ,(Guid courseId , DeleteCourseCommand command) =>{
            command.Handle(courseId);

            return Results.NoContent();
        });
        app.MapDelete("/courses" , (DeleteAllCoursesCommand command)=> 
        {            
            command.Handle();
            return Results.NoContent();
        });
    }
}

