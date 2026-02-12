using Ims.Common.Application.Messaging;

namespace Ims.Modules.Attendance.Application.Tickets.CreateTicket;

public sealed record CreateTicketCommand(Guid TicketId, Guid AttendeeId, Guid EventId, string Code) : ICommand;
