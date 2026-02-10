using Evently.Modules.Events.Application.Events.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

internal static class GetEvent {
    public static void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapGet("events/{id}", async ([FromRoute] Guid id, [FromServices] ISender sender) => {
            var query = new GetEventQuery(id);
            var @event = (EventResponse?)await sender.Send(query);

            return @event is null ? Results.NotFound() : Results.Ok(@event);
        }).WithTags(Tags.Events);
    }
}
