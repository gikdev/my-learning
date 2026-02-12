using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Domain;
using Ims.Modules.Attendance.Application.Tickets.CreateTicket;
using Ims.Modules.Ticketing.IntegrationEvents;
using MediatR;

namespace Ims.Modules.Attendance.Presentation.Tickets;

internal sealed class TicketIssuedIntegrationEventHandler(ISender sender)
    : IntegrationEventHandler<TicketIssuedIntegrationEvent> {
    public override async Task Handle(
        TicketIssuedIntegrationEvent integrationEvent,
        CancellationToken            cancellationToken = default
    ) {
        Result result = await sender.Send(
            new CreateTicketCommand(
                integrationEvent.TicketId,
                integrationEvent.CustomerId,
                integrationEvent.EventId,
                integrationEvent.Code),
            cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(CreateTicketCommand), result.Error);
        }
    }
}
