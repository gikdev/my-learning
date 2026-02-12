using Ims.Common.Application.Exceptions;
using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Tickets.CreateTicketBatch;
using Ims.Modules.Ticketing.Domain.Orders;
using MediatR;

namespace Ims.Modules.Ticketing.Application.Orders.CreateOrder;

internal sealed class CreateTicketsDomainEventHandler(ISender sender)
    : DomainEventHandler<OrderCreatedDomainEvent> {
    public override async Task Handle(
        OrderCreatedDomainEvent notification,
        CancellationToken       cancellationToken = default
    ) {
        Result result = await sender.Send(new CreateTicketBatchCommand(notification.OrderId), cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(CreateTicketBatchCommand), result.Error);
        }
    }
}
