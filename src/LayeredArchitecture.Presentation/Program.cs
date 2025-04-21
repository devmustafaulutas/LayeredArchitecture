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
using Wolverine;
using LayeredArchitecture.Application.Courses.Queries.GetAllCourses;
using LayeredArchitecture.Application.Courses.Commands.DeleteCourse;
using LayeredArchitecture.Application.Courses.Commands.UpdateCourse;
using LayeredArchitecture.Application.Courses.Commands.CreateCourse;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<LayeredArchitectureDbContext>(options =>
    options.UseNpgsql(connectionString,
    b => b.MigrationsAssembly("LayeredArchitecture.Infrastructure"))
);
builder.Services.AddScoped<ILayeredArchitectureDbContext>(sp => sp.GetRequiredService<LayeredArchitectureDbContext>());

var appAssembly = typeof(CreateCourseHandler).Assembly;

// All Services DI 
builder.Services.AddApplicationServices();

// Validators DI
builder.Services.AddCustomValidators();

//Scalar
builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Wolverine as mediatR
builder.Host.UseWolverine(opts =>
{
    // All Assembly's for Wolverine
    // opts.Discovery.IncludeAssembly(appAssembly);
    // opts.Discovery.IncludeAssembly(typeof(ServiceRegisteration).Assembly); // Application
    // opts.Discovery.IncludeAssembly(typeof(ILayeredArchitectureDbContext).Assembly); // Domain
    opts.Discovery.IncludeAssembly(appAssembly);
});


builder.Services.AddScoped<PingWorker>();
//Logging
builder.Logging.AddConsole();
var app = builder.Build();


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
// app.MapControllers();

app.Run();