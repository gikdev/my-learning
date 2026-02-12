using Ims.Common.Application.Messaging;

namespace Ims.Modules.Ticketing.Application.Carts.ClearCart;

public sealed record ClearCartCommand(Guid CustomerId) : ICommand;
