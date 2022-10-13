using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace West.Shared;

public static class NorthwindContextExtensions
{
    /// <summary>
    /// Add NorthwindContext to the specified IServiceCollection. Uses the
    /// Sqlite database provider.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="relativePath">Set to override the default of ".."</param>
    /// <returns>An IServiceCollection that can be use to add more services.</returns>
    public static IServiceCollection AddNorthwindContext(
        this IServiceCollection services, string relativePath = "..")
    {
        string databasePath = Path.Combine(relativePath, "Northwind.db");

        services.AddDbContext<NorthwindContext>(options => 
            options.UseSqlite($"Data Source={databasePath}")
        );

        return services;
    }
}
