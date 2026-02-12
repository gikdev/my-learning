using Ims.Common.Application.EventBus;
using Ims.Common.Application.Exceptions;
using Ims.Common.Domain;
using Ims.Modules.Events.IntegrationEvents;
using Ims.Modules.Ticketing.Application.TicketTypes.UpdateTicketTypePrice;
using MediatR;

namespace Ims.Modules.Ticketing.Presentation.TicketTypes;

internal sealed class TicketTypePriceChangedIntegrationEventHandler(ISender sender)
    : IntegrationEventHandler<TicketTypePriceChangedIntegrationEvent> {
    public override async Task Handle(
        TicketTypePriceChangedIntegrationEvent integrationEvent,
        CancellationToken                      cancellationToken = default
    ) {
        Result result = await sender.Send(
            new UpdateTicketTypePriceCommand(integrationEvent.TicketTypeId, integrationEvent.Price),
            cancellationToken);

        if (result.IsFailure) {
            throw new ImsException(nameof(UpdateTicketTypePriceCommand), result.Error);
        }
    }
}
