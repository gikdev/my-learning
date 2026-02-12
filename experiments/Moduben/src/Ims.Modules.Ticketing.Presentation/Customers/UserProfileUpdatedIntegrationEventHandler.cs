using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Customers.UpdateCustomer;
using Ims.Modules.Users.IntegrationEvents;
using MediatR;

namespace Ims.Modules.Ticketing.Presentation.Customers;

internal sealed class UserProfileUpdatedIntegrationEventHandler(ISender sender)
    : IntegrationEventHandler<UserProfileUpdatedIntegrationEvent> {
    public override async Task Handle(
        UserProfileUpdatedIntegrationEvent integrationEvent,
        CancellationToken                  cancellationToken = default
    ) {
        Result result = await sender.Send(
            new UpdateCustomerCommand(
                integrationEvent.UserId,
                integrationEvent.FirstName,
                integrationEvent.LastName),
            cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(UpdateCustomerCommand), result.Error);
        }
    }
}
