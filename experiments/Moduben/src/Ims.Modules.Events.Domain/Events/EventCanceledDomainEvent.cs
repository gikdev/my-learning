using Ims.Common.Domain;

namespace Ims.Modules.Events.Domain.Events;

public sealed class EventCanceledDomainEvent(Guid eventId) : DomainEvent {
    public Guid EventId { get; init; } = eventId;
}
