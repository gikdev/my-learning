using Ims.Common.Application.EventBus;
using Ims.Common.Application.Messaging;
using Ims.Modules.Events.Domain.TicketTypes;
using Ims.Modules.Events.IntegrationEvents;

namespace Ims.Modules.Events.Application.TicketTypes.UpdateTicketTypePrice;

internal sealed class TicketTypePriceChangedDomainEventHandler(IEventBus eventBus)
    : DomainEventHandler<TicketTypePriceChangedDomainEvent> {
    public override async Task Handle(
        TicketTypePriceChangedDomainEvent domainEvent,
        CancellationToken                 cancellationToken = default
    ) {
        await eventBus.PublishAsync(
            new TicketTypePriceChangedIntegrationEvent(
                domainEvent.Id,
                domainEvent.OccurredOnUtc,
                domainEvent.TicketTypeId,
                domainEvent.Price),
            cancellationToken);
    }
}
