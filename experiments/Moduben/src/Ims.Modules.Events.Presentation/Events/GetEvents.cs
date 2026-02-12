using Ims.Common.Domain;
using Ims.Common.Presentation.Endpoints;
using Ims.Common.Presentation.Results;
using Ims.Modules.Events.Application.Events.GetEvents;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ims.Modules.Events.Presentation.Events;

internal sealed class GetEvents : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapGet("events", async (ISender sender) => {
                Result<IReadOnlyCollection<EventResponse>> result = await sender.Send(new GetEventsQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetEvents)
            .WithTags(Tags.Events);
    }
}
