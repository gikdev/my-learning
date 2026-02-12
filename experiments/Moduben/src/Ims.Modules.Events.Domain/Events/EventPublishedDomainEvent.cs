using Ims.Common.Domain;

namespace Ims.Modules.Events.Domain.Events;

public sealed class EventPublishedDomainEvent(Guid eventId) : DomainEvent {
    public Guid EventId { get; init; } = eventId;
}
