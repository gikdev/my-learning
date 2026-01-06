using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskForge.Api.Constants;
using TaskForge.Application.Labels.Commands.DeleteLabel;

namespace TaskForge.Api.Endpoints.Labels;

public static class DeleteLabelEndpoint {
    public const string Name = "DeleteLabel";
    public const string Summary = "Delete a label";
    public const string Endpoint = ApiEndpoints.Labels.Delete;
    public const string Tag = ApiTags.Labels;

    public static IEndpointRouteBuilder MapDeleteLabel(this IEndpointRouteBuilder app) {
        app
            .MapDelete(Endpoint, Handle)
            .Produces(StatusCodes.Status204NoContent)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender mediator,
        [FromRoute] Guid id
    ) {
        var command = new DeleteLabelCommand(id);

        var result = await mediator.Send(command);

        return result.Match(
            _ => Results.NoContent(),
            ApiResults.Problem
        );
    }
}
