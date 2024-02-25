using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookTracker.Persistence.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContextFactory<BookTrackerDbContext>(options => options.UseInMemoryDatabase("BookTracker"));
        return services;
    }
}
