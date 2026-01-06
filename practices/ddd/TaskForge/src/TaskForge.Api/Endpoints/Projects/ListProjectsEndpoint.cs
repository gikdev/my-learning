using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskForge.Api.Constants;
using TaskForge.Api.Mappings;
using TaskForge.Application.Projects.Queries.ListProjects;
using TaskForge.Contracts.Projects;

namespace TaskForge.Api.Endpoints.Projects;

public static class ListProjectsEndpoint {
    public const string Name = "ListProjects";
    public const string Summary = "List all projects";
    public const string Endpoint = ApiEndpoints.Projects.List;
    public const string Tag = ApiTags.Projects;

    public static IEndpointRouteBuilder MapListProjects(this IEndpointRouteBuilder app) {
        app
            .MapGet(Endpoint, Handle)
            .Produces<IEnumerable<ProjectResponse>>(StatusCodes.Status201Created)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender mediator
    ) {
        var query = new ListProjectsQuery();
        var projects = await mediator.Send(query);
        var response = projects.Select(p => p.MapToResponse());

        return Results.Ok(response);
    }
}
