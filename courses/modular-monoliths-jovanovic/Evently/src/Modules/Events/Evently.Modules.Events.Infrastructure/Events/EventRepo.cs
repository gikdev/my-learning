using Evently.Modules.Events.Domain.Events;
using Evently.Modules.Events.Infrastructure.Database;

namespace Evently.Modules.Events.Infrastructure.Events;

internal sealed class EventRepo(EventsDbCtx db) : IEventRepo
{
    public void Insert(Event @event)
    {
        db.Events.Add(@event);
    }
}
