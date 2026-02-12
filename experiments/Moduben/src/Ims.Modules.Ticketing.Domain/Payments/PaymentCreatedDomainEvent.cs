using Ims.Common.Domain;

namespace Ims.Modules.Ticketing.Domain.Payments;

public sealed class PaymentCreatedDomainEvent(Guid paymentId) : DomainEvent {
    public Guid PaymentId { get; init; } = paymentId;
}
