using Ims.Common.Domain;

namespace Ims.Modules.Ticketing.Domain.Orders;

public sealed class OrderCreatedDomainEvent(Guid orderId) : DomainEvent {
    public Guid OrderId { get; init; } = orderId;
}
