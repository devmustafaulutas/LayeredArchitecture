using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace LayeredArchitecture.Infrastructure.Database;

public class DesingTimeContextFactory : IDesignTimeDbContextFactory<LayeredArchitectureDbContext>
{
    public LayeredArchitectureDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LayeredArchitectureDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=layeredArchitecture;Username=postgres;Password=postgres;Include Error Detail=true");
        return new LayeredArchitectureDbContext(optionsBuilder.Options);
    }
}