using Ims.Common.Domain;

namespace Ims.Modules.Ticketing.Domain.Events;

public sealed class TicketTypeSoldOutDomainEvent(Guid ticketTypeId) : DomainEvent {
    public Guid TicketTypeId { get; init; } = ticketTypeId;
}
