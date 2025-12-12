using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskForge.Api.Constants;
using TaskForge.Api.Mappings;
using TaskForge.Application.Projects.Commands.CreateProject;
using TaskForge.Contracts.Projects;
using DomainProjectStatus = TaskForge.Domain.ProjectAggregate.ProjectStatus;

namespace TaskForge.Api.Endpoints.Projects;

public static class CreateProjectEndpoint {
    public const string Name = "CreateProject";
    public const string Summary = "Create a new project";
    public const string Endpoint = ApiEndpoints.Projects.Create;
    public const string Tag = ApiTags.Projects;

    public static IEndpointRouteBuilder MapCreateProject(this IEndpointRouteBuilder app) {
        app
            .MapPost(Endpoint, Handle)
            .Produces<ProjectResponse>(StatusCodes.Status200OK)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender mediator,
        [FromBody] CreateProjectRequest request
    ) {
        var isThere = request.Status is not null;
        var isValid = DomainProjectStatus.TryFromName(
            request.Status.ToString(),
            out var projectStatus
        );

        if (isThere && !isValid)
            return ApiResults.Problem(Error.Validation("Invalid project status."));

        var command = new CreateProjectCommand(
            request.Title,
            projectStatus
        );

        var result = await mediator.Send(command);

        return result.Match(
            project => Results.Ok(project.MapToResponse()),
            ApiResults.Problem
        );
    }
}
