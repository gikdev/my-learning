using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskForge.Api.Constants;
using TaskForge.Application.Labels.Commands.UpdateLabel;
using TaskForge.Contracts.Labels;

namespace TaskForge.Api.Endpoints.Labels;

public static class UpdateLabelEndpoint {
    public const string Name = "UpdateLabel";
    public const string Summary = "Update a label";
    public const string Endpoint = ApiEndpoints.Labels.Update;
    public const string Tag = ApiTags.Labels;

    public static IEndpointRouteBuilder MapUpdateLabel(this IEndpointRouteBuilder app) {
        app
            .MapPut(Endpoint, Handle)
            .Produces(StatusCodes.Status204NoContent)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender mediator,
        [FromBody] UpdateLabelRequest request,
        [FromRoute] Guid id
    ) {
        var command = new UpdateLabelCommand(id, request.Title);

        var result = await mediator.Send(command);

        return result.Match(
            _ => Results.NoContent(),
            ApiResults.Problem
        );
    }
}
