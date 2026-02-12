using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Domain;
using Ims.Modules.Events.IntegrationEvents;
using Ims.Modules.Ticketing.Application.Events.CancelEvent;
using MediatR;

namespace Ims.Modules.Ticketing.Presentation.Events;

internal sealed class EventCancellationStartedIntegrationEventHandler(ISender sender)
    : IntegrationEventHandler<EventCancellationStartedIntegrationEvent> {
    public override async Task Handle(
        EventCancellationStartedIntegrationEvent integrationEvent,
        CancellationToken                        cancellationToken = default
    ) {
        Result result = await sender.Send(new CancelEventCommand(integrationEvent.EventId), cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(CancelEventCommand), result.Error);
        }
    }
}
