using Ims.Common.Application.EventBus;
using Ims.Common.Application.Messaging;
using Ims.Modules.Ticketing.Domain.Events;
using Ims.Modules.Ticketing.IntegrationEvents;

namespace Ims.Modules.Ticketing.Application.Payments.RefundPaymentsForEvent;

internal sealed class EventPaymentsRefundedDomainEventHandler(IEventBus eventBus)
    : DomainEventHandler<EventPaymentsRefundedDomainEvent> {
    public override async Task Handle(
        EventPaymentsRefundedDomainEvent domainEvent,
        CancellationToken                cancellationToken = default
    ) {
        await eventBus.PublishAsync(
            new EventPaymentsRefundedIntegrationEvent(
                domainEvent.EventId,
                domainEvent.OccurredOnUtc,
                domainEvent.EventId),
            cancellationToken);
    }
}
