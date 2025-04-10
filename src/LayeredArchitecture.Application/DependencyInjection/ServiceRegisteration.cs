using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace LayeredArchitecture.Application.DependencyInjection
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assebly = Assembly.GetExecutingAssembly();

            var types = assebly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && 
                        (type.Name.EndsWith("Command") ||
                        type.Name.EndsWith("Query") ||
                        type.Name.EndsWith("Validator")
                        ));

            foreach (var type in types)
            {
                services.AddScoped(type);
            }

            return services;
        }
    }
}
