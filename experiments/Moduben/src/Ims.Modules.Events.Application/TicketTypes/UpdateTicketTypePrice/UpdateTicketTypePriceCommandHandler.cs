using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Events.Application.Abstractions.Data;
using Ims.Modules.Events.Domain.TicketTypes;

namespace Ims.Modules.Events.Application.TicketTypes.UpdateTicketTypePrice;

internal sealed class UpdateTicketTypePriceCommandHandler(
    ITicketTypeRepository ticketTypeRepository,
    IUnitOfWork           unitOfWork)
    : ICommandHandler<UpdateTicketTypePriceCommand> {
    public async Task<Result> Handle(UpdateTicketTypePriceCommand request, CancellationToken cancellationToken) {
        TicketType? ticketType = await ticketTypeRepository.GetAsync(request.TicketTypeId, cancellationToken);

        if (ticketType is null) {
            return Result.Failure(TicketTypeErrors.NotFound(request.TicketTypeId));
        }

        ticketType.UpdatePrice(request.Price);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
