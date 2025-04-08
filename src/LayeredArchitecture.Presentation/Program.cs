using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.Courses.Commands.CreateCourse;
using LayeredArchitecture.Application.Courses.Commands.DeleteCourse;
using LayeredArchitecture.Application.Courses.Commands.UpdateCourse;
using LayeredArchitecture.Application.Courses.Queries.GetAllCourses;
using LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Commands.DeletePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Commands.UpdatePlannedCourse;
using LayeredArchitecture.Application.PlannedCourses.Queries;
using LayeredArchitecture.Application.Students.Commands.CreateStudent;
using LayeredArchitecture.Application.Students.Commands.DeleteStudent;
using LayeredArchitecture.Application.Students.Commands.UpdateStudent;
using LayeredArchitecture.Application.Students.Queries.GetAllStudents;
using LayeredArchitecture.Application.Validators.Course;
using LayeredArchitecture.Infrastructure.Database;
using LayeredArchitecture.WebApi.Courses;
using LayeredArchitecture.WebApi.PlannedCourses;
using LayeredArchitecture.WebApi.Students;
using Microsoft.EntityFrameworkCore;

// docker run --name pgdev -e POSTGRES_PASSWORD=123456 -d -p 5432:5432 -v C:\Docker\pgdev:/var/lib/postgresql/data  postgres


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<LayeredArchitectureDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"),
    b => b.MigrationsAssembly("LayeredArchitecture.Infrastructure"))
);
builder.Services.AddScoped<ILayeredArchitectureDbContext>(sp => sp.GetRequiredService<LayeredArchitectureDbContext>());

builder.Services.AddScoped<GetAllCoursesQuery>();
builder.Services.AddScoped<CreateCourseCommand>();
builder.Services.AddScoped<UpdateCourseCommand>();
builder.Services.AddScoped<DeleteCourseCommand>();
builder.Services.AddScoped<DeleteAllCoursesCommand>();
builder.Services.AddScoped<CreatePlannedCourseCommand>();
builder.Services.AddScoped<UpdatePlannedCourseCommand>();
builder.Services.AddScoped<DeletePlannedCourseCommand>();
builder.Services.AddScoped<GetAllPlannedCoursesQuery>();
builder.Services.AddScoped<GetAllStudentsQuery>();
builder.Services.AddScoped<StudentCreateCommand>();
builder.Services.AddScoped<StudentUpdateCommand>();
builder.Services.AddScoped<StudentDeleteCommand>();
builder.Services.AddScoped<CreateCourseValidator>();
builder.Services.AddScoped<UpdateCourseValidator>();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Logging
builder.Logging.AddConsole();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Controllers
app.AddPlannedCoursesEndpoints();
app.AddCoursesEndpoints();
app.AddStudentEndpoints();

app.Run();
