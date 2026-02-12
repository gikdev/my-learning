using Ims.Common.Domain;

namespace Ims.Modules.Events.Domain.TicketTypes;

public sealed class TicketTypeCreatedDomainEvent(Guid ticketTypeId) : DomainEvent {
    public Guid TicketTypeId { get; init; } = ticketTypeId;
}
