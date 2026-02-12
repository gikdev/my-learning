using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Customers.CreateCustomer;
using Ims.Modules.Users.IntegrationEvents;
using MediatR;

namespace Ims.Modules.Ticketing.Presentation.Customers;

internal sealed class UserRegisteredIntegrationEventHandler(ISender sender)
    : IntegrationEventHandler<UserRegisteredIntegrationEvent> {
    public override async Task Handle(
        UserRegisteredIntegrationEvent integrationEvent,
        CancellationToken              cancellationToken = default
    ) {
        Result result = await sender.Send(
            new CreateCustomerCommand(
                integrationEvent.UserId,
                integrationEvent.Email,
                integrationEvent.FirstName,
                integrationEvent.LastName),
            cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(CreateCustomerCommand), result.Error);
        }
    }
}
