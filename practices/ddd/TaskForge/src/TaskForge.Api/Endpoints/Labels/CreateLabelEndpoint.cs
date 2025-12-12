using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskForge.Api.Constants;
using TaskForge.Api.Mappings;
using TaskForge.Application.Labels.Commands.CreateLabel;
using TaskForge.Contracts.Labels;

namespace TaskForge.Api.Endpoints.Labels;

public static class CreateLabelEndpoint {
    public const string Name = "CreateLabel";
    public const string Summary = "Create a new label";
    public const string Endpoint = ApiEndpoints.Labels.Create;
    public const string Tag = ApiTags.Labels;

    public static IEndpointRouteBuilder MapCreateLabel(this IEndpointRouteBuilder app) {
        app
            .MapPost(Endpoint, Handle)
            .Produces<LabelResponse>(StatusCodes.Status200OK)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender mediator,
        [FromBody] CreateLabelRequest request
    ) {
        var command = new CreateLabelCommand(request.Title);

        var result = await mediator.Send(command);

        return result.Match(
            label => Results.Ok(label.MapToResponse()),
            ApiResults.Problem
        );
    }
}
