using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Events.Application.Events.GetEvent;
using Ims.Modules.Events.Domain.Events;
using Ims.Modules.Events.IntegrationEvents;
using MediatR;

namespace Ims.Modules.Events.Application.Events.PublishEvent;

internal sealed class EventPublishedDomainEventHandler(ISender sender, IEventBus eventBus)
    : DomainEventHandler<EventPublishedDomainEvent> {
    public override async Task Handle(
        EventPublishedDomainEvent domainEvent,
        CancellationToken         cancellationToken = default
    ) {
        Result<EventResponse> result = await sender.Send(new GetEventQuery(domainEvent.EventId), cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(GetEventQuery), result.Error);
        }

        await eventBus.PublishAsync(
            new EventPublishedIntegrationEvent(
                domainEvent.Id,
                domainEvent.OccurredOnUtc,
                result.Value.Id,
                result.Value.Title,
                result.Value.Description,
                result.Value.Location,
                result.Value.StartsAtUtc,
                result.Value.EndsAtUtc,
                result.Value.TicketTypes.Select(t => new TicketTypeModel {
                    Id       = t.TicketTypeId,
                    EventId  = result.Value.Id,
                    Name     = t.Name,
                    Price    = t.Price,
                    Currency = t.Currency,
                    Quantity = t.Quantity
                }).ToList()),
            cancellationToken);
    }
}
