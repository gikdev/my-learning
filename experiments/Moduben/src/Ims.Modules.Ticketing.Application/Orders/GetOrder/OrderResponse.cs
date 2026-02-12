using Ims.Modules.Ticketing.Domain.Orders;

namespace Ims.Modules.Ticketing.Application.Orders.GetOrder;

public sealed record OrderResponse(
    Guid        Id,
    Guid        CustomerId,
    OrderStatus Status,
    decimal     TotalPrice,
    DateTime    CreatedAtUtc) {
    public List<OrderItemResponse> OrderItems { get; } = [];
}
