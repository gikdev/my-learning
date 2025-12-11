using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskForge.Api.Constants;
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
            .MapPost(Endpoint, HandleCreateLabel)
            .Produces<LabelResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> HandleCreateLabel(
        [FromServices] ISender mediator,
        [FromBody] CreateLabelRequest request
    ) {
        var command = new CreateLabelCommand(request.Title);

        var createLabelResult = await mediator.Send(command);

        return createLabelResult.Match(
            // label => Results.CreatedAtRoute(
            //     nameof(GetLabelByIdEndpoint.Name),
            //     new { id = label.Id },
            //     label.MapToResponse()
            // ),
            _ => Results.Created(),
            ApiResults.Problem
        );
    }
}
