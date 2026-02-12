using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Domain;
using Ims.Modules.Attendance.Application.Attendees.UpdateAttendee;
using Ims.Modules.Users.IntegrationEvents;
using MediatR;

namespace Ims.Modules.Attendance.Presentation.Attendees;

internal sealed class UserProfileUpdatedIntegrationEventHandler(ISender sender)
    : IntegrationEventHandler<UserProfileUpdatedIntegrationEvent> {
    public override async Task Handle(
        UserProfileUpdatedIntegrationEvent integrationEvent,
        CancellationToken                  cancellationToken = default
    ) {
        Result result = await sender.Send(
            new UpdateAttendeeCommand(
                integrationEvent.UserId,
                integrationEvent.FirstName,
                integrationEvent.LastName),
            cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(UpdateAttendeeCommand), result.Error);
        }
    }
}
