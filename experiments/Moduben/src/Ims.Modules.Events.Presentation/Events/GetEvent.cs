using Ims.Common.Domain;
using Ims.Common.Presentation.Endpoints;
using Ims.Common.Presentation.Results;
using Ims.Modules.Events.Application.Events.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ims.Modules.Events.Presentation.Events;

internal sealed class GetEvent : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapGet("events/{id}", async (Guid id, ISender sender) => {
                Result<EventResponse> result = await sender.Send(new GetEventQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetEvents)
            .WithTags(Tags.Events);
    }
}
