using TaskForge.Api.Endpoints.Labels;

namespace TaskForge.Api.Endpoints;

public static class EndpointsExtensions {
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app) {
        // Labels
        app.MapCreateLabel();

        return app;
    }
}
