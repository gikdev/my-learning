using Ims.Common.Application.EventBus;
using Ims.Common.Application.Messaging;
using Ims.Modules.Events.Domain.Events;
using Ims.Modules.Events.IntegrationEvents;

namespace Ims.Modules.Events.Application.Events.CancelEvent;

internal sealed class EventCanceledDomainEventHandler(IEventBus eventBus)
    : DomainEventHandler<EventCanceledDomainEvent> {
    public override async Task Handle(
        EventCanceledDomainEvent domainEvent,
        CancellationToken        cancellationToken = default
    ) {
        await eventBus.PublishAsync(
            new EventCanceledIntegrationEvent(
                domainEvent.Id,
                domainEvent.OccurredOnUtc,
                domainEvent.EventId),
            cancellationToken);
    }
}
