using Ims.Common.Application.EventBus;

namespace Ims.Modules.Ticketing.IntegrationEvents;

public sealed class EventPaymentsRefundedIntegrationEvent : IntegrationEvent {
    public EventPaymentsRefundedIntegrationEvent(Guid id, DateTime occurredOnUtc, Guid eventId)
        : base(id, occurredOnUtc) {
        EventId = eventId;
    }

    public Guid EventId { get; init; }
}
