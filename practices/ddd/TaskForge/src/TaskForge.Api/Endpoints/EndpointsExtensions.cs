using TaskForge.Api.Endpoints.Labels;

namespace TaskForge.Api.Endpoints;

public static class EndpointsExtensions {
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app) {
        // Labels
        app.MapCreateLabel();
        app.MapGetLabelById();
        app.MapListLabels();

        return app;
    }
}
