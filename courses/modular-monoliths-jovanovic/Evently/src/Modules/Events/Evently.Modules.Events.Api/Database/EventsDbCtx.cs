using Evently.Modules.Events.Api.Events;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Api.Database;

public sealed class EventsDbCtx(DbContextOptions<EventsDbCtx> options) : DbContext(options)
{
    internal DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}
