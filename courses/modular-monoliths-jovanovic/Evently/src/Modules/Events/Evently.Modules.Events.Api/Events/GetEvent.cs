using Evently.Modules.Events.Api.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Api.Events;

public static class GetEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id}", async ([FromRoute] Guid id, EventsDbCtx db) =>
        {
            EventResponse? @event = await db.Events
                .Where(e => e.Id == id)
                .Select(e => new EventResponse
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Location = e.Location,
                    StartsAtUtc = e.StartsAtUtc,
                    EndsAtUtc = e.EndsAtUtc,
                })
                .SingleOrDefaultAsync();

            return @event is null ? Results.NotFound() : Results.Ok(@event);
        }).WithTags(Tags.Events);
    }
}
