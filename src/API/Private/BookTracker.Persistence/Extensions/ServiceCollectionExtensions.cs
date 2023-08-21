using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookTracker.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<BookTrackerDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IBookTrackerDbContext>(provider => provider.GetRequiredService<BookTrackerDbContext>());
        return services;
    }
}
