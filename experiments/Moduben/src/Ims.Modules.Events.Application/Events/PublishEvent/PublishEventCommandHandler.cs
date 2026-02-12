using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Events.Application.Abstractions.Data;
using Ims.Modules.Events.Domain.Events;
using Ims.Modules.Events.Domain.TicketTypes;

namespace Ims.Modules.Events.Application.Events.PublishEvent;

internal sealed class PublishEventCommandHandler(
    IEventRepository      eventRepository,
    ITicketTypeRepository ticketTypeRepository,
    IUnitOfWork           unitOfWork)
    : ICommandHandler<PublishEventCommand> {
    public async Task<Result> Handle(PublishEventCommand request, CancellationToken cancellationToken) {
        Event? @event = await eventRepository.GetAsync(request.EventId, cancellationToken);

        if (@event is null) {
            return Result.Failure(EventErrors.NotFound(request.EventId));
        }

        if (!await ticketTypeRepository.ExistsAsync(@event.Id, cancellationToken)) {
            return Result.Failure(EventErrors.NoTicketsFound);
        }

        @event.Publish();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
