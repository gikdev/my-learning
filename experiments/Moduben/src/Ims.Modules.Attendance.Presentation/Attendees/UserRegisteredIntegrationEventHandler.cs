using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Domain;
using Ims.Modules.Attendance.Application.Attendees.CreateAttendee;
using Ims.Modules.Users.IntegrationEvents;
using MediatR;

namespace Ims.Modules.Attendance.Presentation.Attendees;

internal sealed class UserRegisteredIntegrationEventHandler(ISender sender)
    : IntegrationEventHandler<UserRegisteredIntegrationEvent> {
    public override async Task Handle(
        UserRegisteredIntegrationEvent integrationEvent,
        CancellationToken              cancellationToken = default
    ) {
        Result result = await sender.Send(
            new CreateAttendeeCommand(
                integrationEvent.UserId,
                integrationEvent.Email,
                integrationEvent.FirstName,
                integrationEvent.LastName),
            cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(CreateAttendeeCommand), result.Error);
        }
    }
}
