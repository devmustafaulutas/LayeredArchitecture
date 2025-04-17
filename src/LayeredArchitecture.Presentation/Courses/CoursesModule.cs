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
        var group = app.MapGroup("/api/v1/courses")
                    .WithTags("Courses");


        group.MapGet("/", (GetAllCoursesQuery query) =>
        {
            var result = query.Handle();
            return Results.Ok(result);
        });

        group.MapPost("/",  ( CreateCourseCommand command)=>command);

        group.MapPut("/{courseId:guid}", (Guid courseId, [FromBody] UpdateCourseDto courseDto, UpdateCourseCommand command) => {
            command.Handle(courseId, courseDto);

            return Results.NoContent();
        });
        group.MapDelete("/{courseId:guid}" ,(Guid courseId , DeleteCourseCommand command) =>{
            command.Handle(courseId);

            return Results.NoContent();
        });
        group.MapDelete("/" , (DeleteAllCoursesCommand command)=> 
        {            
            command.Handle();
            return Results.NoContent(); 
        });
    }
}

