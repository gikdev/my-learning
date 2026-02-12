using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Domain;
using Ims.Modules.Attendance.Application.Events.CreateEvent;
using Ims.Modules.Events.IntegrationEvents;
using MediatR;

namespace Ims.Modules.Attendance.Presentation.Events;

internal sealed class EventPublishedIntegrationEventHandler(ISender sender)
    : IntegrationEventHandler<EventPublishedIntegrationEvent> {
    public override async Task Handle(
        EventPublishedIntegrationEvent integrationEvent,
        CancellationToken              cancellationToken = default
    ) {
        Result result = await sender.Send(
            new CreateEventCommand(
                integrationEvent.EventId,
                integrationEvent.Title,
                integrationEvent.Description,
                integrationEvent.Location,
                integrationEvent.StartsAtUtc,
                integrationEvent.EndsAtUtc),
            cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(CreateEventCommand), result.Error);
        }
    }
}
