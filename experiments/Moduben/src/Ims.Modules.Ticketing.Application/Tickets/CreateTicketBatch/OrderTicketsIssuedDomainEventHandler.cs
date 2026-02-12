using Ims.Common.Application.Exceptions;
using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Tickets.GetTicket;
using Ims.Modules.Ticketing.Application.Tickets.GetTicketForOrder;
using Ims.Modules.Ticketing.Domain.Orders;
using MediatR;

namespace Ims.Modules.Ticketing.Application.Tickets.CreateTicketBatch;

internal sealed class OrderTicketsIssuedDomainEventHandler(ISender sender)
    : DomainEventHandler<OrderTicketsIssuedDomainEvent> {
    public override async Task Handle(
        OrderTicketsIssuedDomainEvent domainEvent,
        CancellationToken             cancellationToken = default
    ) {
        Result<IReadOnlyCollection<TicketResponse>> result = await sender.Send(
            new GetTicketsForOrderQuery(domainEvent.OrderId), cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(GetTicketsForOrderQuery), result.Error);
        }

        // Send ticket confirmation notification.
    }
}
