using Ims.Common.Application.EventBus;
using Ims.Common.Application.Messaging;
using Ims.Modules.Ticketing.Domain.Events;
using Ims.Modules.Ticketing.IntegrationEvents;

namespace Ims.Modules.Ticketing.Application.TicketTypes;

internal sealed class TicketTypeSoldOutDomainEventHandler(IEventBus eventBus)
    : DomainEventHandler<TicketTypeSoldOutDomainEvent> {
    public override async Task Handle(
        TicketTypeSoldOutDomainEvent domainEvent,
        CancellationToken            cancellationToken = default
    ) {
        await eventBus.PublishAsync(
            new TicketTypeSoldOutIntegrationEvent(
                domainEvent.Id,
                domainEvent.OccurredOnUtc,
                domainEvent.TicketTypeId),
            cancellationToken);
    }
}
