using System.Diagnostics.CodeAnalysis;
using BookTracker.Private.Api.Endpoints;

namespace BookTracker.Private.Api.Extensions;

[ExcludeFromCodeCoverage]
public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var endpoints = typeof(Program).Assembly
            .GetTypes()
            .Where(x => x.GetInterfaces().Any(i => i == typeof(IEndpointRegister)))
            .Select(Activator.CreateInstance)
            .Cast<IEndpointRegister>();

        foreach (var endpoint in endpoints)
        {
            endpoint.RegisterEndpoint(endpointRouteBuilder);
        }
        
        return endpointRouteBuilder;
    }
}