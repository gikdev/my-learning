using Ims.Common.Application.Messaging;
using Ims.Modules.Ticketing.Application.Tickets.GetTicket;

namespace Ims.Modules.Ticketing.Application.Tickets.GetTicketForOrder;

public sealed record GetTicketsForOrderQuery(Guid OrderId) : IQuery<IReadOnlyCollection<TicketResponse>>;
