using Ims.Common.Application.Messaging;
using Ims.Modules.Ticketing.Application.Abstractions.Payments;
using Ims.Modules.Ticketing.Domain.Payments;

namespace Ims.Modules.Ticketing.Application.Payments.RefundPayment;

internal sealed class PaymentRefundedDomainEventHandler(IPaymentService paymentService)
    : DomainEventHandler<PaymentRefundedDomainEvent> {
    public override async Task Handle(
        PaymentRefundedDomainEvent domainEvent,
        CancellationToken          cancellationToken = default
    ) {
        await paymentService.RefundAsync(domainEvent.TransactionId, domainEvent.RefundAmount);
    }
}
