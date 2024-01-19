using System.Diagnostics.CodeAnalysis;
using BookTracker.BusinessLogic.Behaviors;
using BookTracker.BusinessLogic.Services.Password;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace BookTracker.BusinessLogic.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Singleton);
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        services.AddSingleton<IPasswordService, PasswordService>();

        return services;
    }
}