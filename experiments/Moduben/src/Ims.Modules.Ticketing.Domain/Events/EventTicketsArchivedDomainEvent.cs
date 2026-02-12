using Ims.Common.Domain;

namespace Ims.Modules.Ticketing.Domain.Events;

public sealed class EventTicketsArchivedDomainEvent(Guid eventId) : DomainEvent {
    public Guid EventId { get; init; } = eventId;
}
