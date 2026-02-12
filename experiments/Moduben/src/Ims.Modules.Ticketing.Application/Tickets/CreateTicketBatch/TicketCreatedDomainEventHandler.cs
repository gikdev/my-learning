using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Tickets.GetTicket;
using Ims.Modules.Ticketing.Domain.Tickets;
using Ims.Modules.Ticketing.IntegrationEvents;
using MediatR;

namespace Ims.Modules.Ticketing.Application.Tickets.CreateTicketBatch;

internal sealed class TicketCreatedDomainEventHandler(ISender sender, IEventBus eventBus)
    : DomainEventHandler<TicketCreatedDomainEvent> {
    public override async Task Handle(
        TicketCreatedDomainEvent domainEvent,
        CancellationToken        cancellationToken = default
    ) {
        Result<TicketResponse> result = await sender.Send(
            new GetTicketQuery(domainEvent.TicketId),
            cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(GetTicketQuery), result.Error);
        }

        await eventBus.PublishAsync(
            new TicketIssuedIntegrationEvent(
                domainEvent.Id,
                domainEvent.OccurredOnUtc,
                result.Value.Id,
                result.Value.CustomerId,
                result.Value.EventId,
                result.Value.Code),
            cancellationToken);
    }
}
