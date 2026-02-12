using Ims.Common.Application.Exceptions;
using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Orders.GetOrder;
using Ims.Modules.Ticketing.Domain.Orders;
using MediatR;

namespace Ims.Modules.Ticketing.Application.Orders.CreateOrder;

internal sealed class SendOrderConfirmationDomainEventHandler(ISender sender)
    : DomainEventHandler<OrderCreatedDomainEvent> {
    public override async Task Handle(
        OrderCreatedDomainEvent notification,
        CancellationToken       cancellationToken = default
    ) {
        Result<OrderResponse> result = await sender.Send(new GetOrderQuery(notification.OrderId), cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(GetOrderQuery), result.Error);
        }

        // Send order confirmation notification.
    }
}
