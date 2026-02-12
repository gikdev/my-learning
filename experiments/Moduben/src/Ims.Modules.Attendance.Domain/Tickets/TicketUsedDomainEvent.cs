using Ims.Common.Domain;

namespace Ims.Modules.Attendance.Domain.Tickets;

public sealed class TicketUsedDomainEvent(Guid ticketId) : DomainEvent {
    public Guid TicketId { get; init; } = ticketId;
}
