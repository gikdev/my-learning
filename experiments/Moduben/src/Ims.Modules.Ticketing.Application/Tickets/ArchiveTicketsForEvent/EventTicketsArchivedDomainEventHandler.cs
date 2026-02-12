using Ims.Common.Application.EventBus;
using Ims.Common.Application.Messaging;
using Ims.Modules.Ticketing.Domain.Events;
using Ims.Modules.Ticketing.IntegrationEvents;

namespace Ims.Modules.Ticketing.Application.Tickets.ArchiveTicketsForEvent;

internal sealed class EventTicketsArchivedDomainEventHandler(IEventBus eventBus)
    : DomainEventHandler<EventTicketsArchivedDomainEvent> {
    public override async Task Handle(
        EventTicketsArchivedDomainEvent domainEvent,
        CancellationToken               cancellationToken = default
    ) {
        await eventBus.PublishAsync(
            new EventTicketsArchivedIntegrationEvent(
                domainEvent.EventId,
                domainEvent.OccurredOnUtc,
                domainEvent.EventId),
            cancellationToken);
    }
}
