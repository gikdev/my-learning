using TaskForge.Api.Endpoints.Labels;
using TaskForge.Api.Endpoints.Projects;

namespace TaskForge.Api.Endpoints;

public static class EndpointsExtensions {
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app) {
        // Labels
        app.MapCreateLabel();
        app.MapDeleteLabel();
        app.MapGetLabelById();
        app.MapListLabels();
        app.MapUpdateLabel();

        // Projects
        app.MapCreateProject();
        app.MapListProjects();

        return app;
    }
}
