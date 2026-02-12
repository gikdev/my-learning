using Ims.Common.Application.EventBus;
using Ims.Common.Application.Messaging;
using Ims.Modules.Events.Domain.Events;
using Ims.Modules.Events.IntegrationEvents;

namespace Ims.Modules.Events.Application.Events.RescheduleEvent;

internal sealed class EventRescheduledDomainEventHandler(IEventBus eventBus)
    : DomainEventHandler<EventRescheduledDomainEvent> {
    public override async Task Handle(
        EventRescheduledDomainEvent domainEvent,
        CancellationToken           cancellationToken = default
    ) {
        await eventBus.PublishAsync(
            new EventRescheduledIntegrationEvent(
                domainEvent.Id,
                domainEvent.OccurredOnUtc,
                domainEvent.EventId,
                domainEvent.StartsAtUtc,
                domainEvent.EndsAtUtc),
            cancellationToken);
    }
}
