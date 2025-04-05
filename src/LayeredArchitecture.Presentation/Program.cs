using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.Courses.Commands.CreateCourse;
using LayeredArchitecture.Application.Courses.Commands.DeleteCourse;
using LayeredArchitecture.Application.Courses.Commands.UpdateCourse;
using LayeredArchitecture.Application.Courses.Queries.GetAllCourses;
using LayeredArchitecture.Infrastructure.Database;
using LayeredArchitecture.WebApi.Courses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<LayeredArchitectureDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<ILayeredArchitectureDbContext>(sp => sp.GetRequiredService<LayeredArchitectureDbContext>());

builder.Services.AddScoped<GetAllCoursesQuery>();
builder.Services.AddScoped<CreateCourseCommand>();
builder.Services.AddScoped<UpdateCourseCommand>();
builder.Services.AddScoped<DeleteCourseCommand>();

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

app.AddCoursesEndpoints();

app.Run();
