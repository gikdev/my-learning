using Ims.Common.Application.Messaging;
using Ims.Modules.Ticketing.Application.Abstractions.Payments;
using Ims.Modules.Ticketing.Domain.Payments;

namespace Ims.Modules.Ticketing.Application.Payments.RefundPayment;

internal sealed class PaymentPartiallyRefundedDomainEventHandler(IPaymentService paymentService)
    : DomainEventHandler<PaymentPartiallyRefundedDomainEvent> {
    public override async Task Handle(
        PaymentPartiallyRefundedDomainEvent domainEvent,
        CancellationToken                   cancellationToken = default
    ) {
        await paymentService.RefundAsync(domainEvent.TransactionId, domainEvent.RefundAmount);
    }
}
