using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Abstractions.Data;
using Ims.Modules.Ticketing.Domain.Payments;

namespace Ims.Modules.Ticketing.Application.Payments.RefundPayment;

internal sealed class RefundPaymentCommandHandler(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<RefundPaymentCommand> {
    public async Task<Result> Handle(RefundPaymentCommand request, CancellationToken cancellationToken) {
        Payment? payment = await paymentRepository.GetAsync(request.PaymentId, cancellationToken);

        if (payment is null) {
            return Result.Failure(PaymentErrors.NotFound(request.PaymentId));
        }

        Result result = payment.Refund(request.Amount);

        if (result.IsFailure) {
            return Result.Failure(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
