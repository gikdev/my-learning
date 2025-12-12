using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskForge.Api.Constants;
using TaskForge.Api.Mappings;
using TaskForge.Application.Labels.Queries.GetLabel;
using TaskForge.Contracts.Labels;

namespace TaskForge.Api.Endpoints.Labels;

public static class GetLabelByIdEndpoint {
    public const string Name = "GetLabelById";
    public const string Summary = "Get a label by ID";
    public const string Endpoint = ApiEndpoints.Labels.GetById;
    public const string Tag = ApiTags.Labels;

    public static IEndpointRouteBuilder MapGetLabelById(this IEndpointRouteBuilder app) {
        app
            .MapGet(Endpoint, Handle)
            .Produces<LabelResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> Handle(
        [FromServices] ISender mediator,
        [FromRoute] Guid id
    ) {
        var query = new GetLabelQuery(id);

        var getLabelResult = await mediator.Send(query);

        return getLabelResult.Match(
            label => Results.Ok(label.MapToResponse()),
            ApiResults.Problem
        );
    }
}
