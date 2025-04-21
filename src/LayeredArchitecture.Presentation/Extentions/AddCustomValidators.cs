using FluentValidation;
using LayeredArchitecture.Application.Validators.Course;

public static class ValidationServiceRegistration
{
    public static IServiceCollection AddCustomValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CreateCourseCommandValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateCourseCommandValidator).Assembly);
        return services;
    }
}
