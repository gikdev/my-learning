using Ims.Common.Application.EventBus;
using Ims.Common.Application.Messaging;
using Ims.Modules.Ticketing.Domain.Tickets;
using Ims.Modules.Ticketing.IntegrationEvents;

namespace Ims.Modules.Ticketing.Application.Tickets.ArchiveTicket;

internal sealed class TicketArchivedDomainEventHandler(IEventBus eventBus)
    : DomainEventHandler<TicketArchivedDomainEvent> {
    public override async Task Handle(
        TicketArchivedDomainEvent domainEvent,
        CancellationToken         cancellationToken = default
    ) {
        await eventBus.PublishAsync(
            new TicketArchivedIntegrationEvent(
                domainEvent.Id,
                domainEvent.OccurredOnUtc,
                domainEvent.TicketId,
                domainEvent.Code),
            cancellationToken);
    }
}
