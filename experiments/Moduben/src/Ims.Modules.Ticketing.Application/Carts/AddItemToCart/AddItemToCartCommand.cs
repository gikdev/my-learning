using Ims.Common.Application.Messaging;

namespace Ims.Modules.Ticketing.Application.Carts.AddItemToCart;

public sealed record AddItemToCartCommand(Guid CustomerId, Guid TicketTypeId, decimal Quantity)
    : ICommand;
