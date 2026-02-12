using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Orders.GetOrder;
using Ims.Modules.Ticketing.Domain.Orders;
using Ims.Modules.Ticketing.IntegrationEvents;
using MediatR;

namespace Ims.Modules.Ticketing.Application.Orders.CreateOrder;

internal sealed class OrderCreatedDomainEventHandler(ISender sender, IEventBus eventBus)
    : DomainEventHandler<OrderCreatedDomainEvent> {
    public override async Task Handle(
        OrderCreatedDomainEvent notification,
        CancellationToken       cancellationToken = default
    ) {
        Result<OrderResponse> result = await sender.Send(new GetOrderQuery(notification.OrderId), cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(GetOrderQuery), result.Error);
        }

        await eventBus.PublishAsync(
            new OrderCreatedIntegrationEvent(
                notification.Id,
                notification.OccurredOnUtc,
                result.Value.Id,
                result.Value.CustomerId,
                result.Value.TotalPrice,
                result.Value.CreatedAtUtc,
                result.Value.OrderItems.Select(oi => new OrderItemModel {
                    Id           = oi.OrderItemId,
                    OrderId      = result.Value.Id,
                    TicketTypeId = oi.TicketTypeId,
                    Price        = oi.Price,
                    UnitPrice    = oi.UnitPrice,
                    Currency     = oi.Currency,
                    Quantity     = oi.Quantity
                }).ToList()),
            cancellationToken);
    }
}
