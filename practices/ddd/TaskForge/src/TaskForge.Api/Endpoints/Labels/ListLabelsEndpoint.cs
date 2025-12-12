using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskForge.Api.Constants;
using TaskForge.Api.Mappings;
using TaskForge.Application.Labels.Queries.ListLabels;
using TaskForge.Contracts.Labels;

namespace TaskForge.Api.Endpoints.Labels;

public static class ListLabelsEndpoint {
    public const string Name = "ListLabels";
    public const string Summary = "List labels";
    public const string Endpoint = ApiEndpoints.Labels.List;
    public const string Tag = ApiTags.Labels;

    public static IEndpointRouteBuilder MapListLabels(this IEndpointRouteBuilder app) {
        app
            .MapGet(Endpoint, HandleListLabels)
            .Produces<IEnumerable<LabelResponse>>(StatusCodes.Status200OK)
            .WithSummary(Summary)
            .WithName(Name)
            .WithTags(Tag);

        return app;
    }

    private static async Task<IResult> HandleListLabels(
        [FromServices] ISender mediator
    ) {
        var query = new ListLabelsQuery();

        var labels = await mediator.Send(query);

        var response = labels.Select(l => l.MapToResponse());

        return Results.Ok(response);
    }
}
