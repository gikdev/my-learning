using Ims.Common.Application.Exceptions;
using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Tickets.ArchiveTicketsForEvent;
using Ims.Modules.Ticketing.Domain.Events;
using MediatR;

namespace Ims.Modules.Ticketing.Application.Events.CancelEvent;

internal sealed class ArchiveTicketsEventCanceledDomainEventHandler(ISender sender)
    : DomainEventHandler<EventCanceledDomainEvent> {
    public override async Task Handle(
        EventCanceledDomainEvent domainEvent,
        CancellationToken        cancellationToken = default
    ) {
        Result result = await sender.Send(new ArchiveTicketsForEventCommand(domainEvent.EventId), cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(ArchiveTicketsForEventCommand), result.Error);
        }
    }
}
