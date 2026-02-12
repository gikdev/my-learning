using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Attendance.Application.Abstractions.Data;
using Ims.Modules.Attendance.Domain.Events;

namespace Ims.Modules.Attendance.Application.Events.CreateEvent;

internal sealed class CreateEventCommandHandler(
    IEventRepository eventRepository,
    IUnitOfWork      unitOfWork)
    : ICommandHandler<CreateEventCommand> {
    public async Task<Result> Handle(CreateEventCommand request, CancellationToken cancellationToken) {
        var @event = Event.Create(
            request.EventId,
            request.Title,
            request.Description,
            request.Location,
            request.StartsAtUtc,
            request.EndsAtUtc);

        eventRepository.Insert(@event);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
