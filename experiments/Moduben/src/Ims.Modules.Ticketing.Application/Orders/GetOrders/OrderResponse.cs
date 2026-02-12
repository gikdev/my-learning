using Ims.Modules.Ticketing.Domain.Orders;

namespace Ims.Modules.Ticketing.Application.Orders.GetOrders;

public sealed record OrderResponse(
    Guid        Id,
    Guid        CustomerId,
    OrderStatus Status,
    decimal     TotalPrice,
    DateTime    CreatedAtUtc);
