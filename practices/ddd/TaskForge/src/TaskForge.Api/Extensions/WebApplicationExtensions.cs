using Scalar.AspNetCore;
using TaskForge.Api.Endpoints;

namespace TaskForge.Api.Extensions;

public static class WebApplicationExtensions {
    public static IServiceCollection AddApiStuff(this IServiceCollection services) {
        services.AddOpenApi();

        return services;
    }

    public static WebApplication MapApiStuff(this WebApplication app) {
        app.MapOpenApi();
        app.MapScalarApiReference();
        app.MapApiEndpoints();

        return app;
    }
}
