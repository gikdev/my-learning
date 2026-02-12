using Ims.Common.Domain;

namespace Ims.Modules.Ticketing.Domain.Events;

public sealed class EventCanceledDomainEvent(Guid eventId) : DomainEvent {
    public Guid EventId { get; } = eventId;
}
