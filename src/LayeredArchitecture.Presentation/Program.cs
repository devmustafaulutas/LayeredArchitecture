using LayeredArchitecture.Infrastructure.Database;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.DependencyInjection;
using LayeredArchitecture.WebApi.Students;
using LayeredArchitecture.WebApi.Courses;
using LayeredArchitecture.WebApi.PlannedCourses;
using LayeredArchitecture.WebApi.PlannedCourseStudents;
using LayeredArchitecture.WebApi.PlannedCourseSessions;
using LayeredArchitecture.WebApi.StudentPayments;
using LayeredArchitecture.WebApi.PlannedCourseSessionDiscontinuities;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LayeredArchitectureDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"),
    b => b.MigrationsAssembly("LayeredArchitecture.Infrastructure"))
);
builder.Services.AddScoped<ILayeredArchitectureDbContext>(sp => sp.GetRequiredService<LayeredArchitectureDbContext>());

// All Services DI 
builder.Services.AddApplicationServices();

// Validators DI
builder.Services.AddCustomValidators();

// Wolverine'i DI container'a ekle
// builder.Host.UseWolverine();
//Swagger
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

//Scalar
builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Logging
builder.Logging.AddConsole();
var app = builder.Build();

// Configure the HTTP request pipeline.
// Swagger
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// Scalar
app.MapOpenApi();
app.MapScalarApiReference(opt =>
{
    opt
        .WithTitle("Test Api")
        .WithTheme(ScalarTheme.Default)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

app.UseHttpsRedirection();

//Controllers
app.AddPlannedCoursesEndpoints();
app.AddCoursesEndpoints();
app.AddStudentEndpoints();
app.AddPlannedCourseStudentsEndPoints();
app.AddPlannedCourseSessionsEndPoints();
app.AddStudentPaymentEndPoints();
app.AddDiscontinuityEndPoints();

//For scalar
app.MapControllers();

app.Run();
