using Ims.Common.Application.Messaging;
using Ims.Modules.Ticketing.Application.Tickets.GetTicket;

namespace Ims.Modules.Ticketing.Application.Tickets.GetTicketByCode;

public sealed record GetTicketByCodeQuery(string Code) : IQuery<TicketResponse>;
