using Evently.Modules.Events.Api.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Api.Events;

public static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async ([FromBody] Request request, [FromServices] EventsDbCtx db) =>
        {
            var @event = new Event
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                EndsAtUtc = request.EndsAtUtc,
                StartsAtUtc = request.StartsAtUtc,
                Status = EventStatus.Draft,
            };

            db.Events.Add(@event);

            await db.SaveChangesAsync();

            return Results.Ok(@event.Id);
        }).WithTags(Tags.Events);
    }

    internal sealed class Request
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartsAtUtc { get; set; }
        public DateTime? EndsAtUtc { get; set; }
    }
}
