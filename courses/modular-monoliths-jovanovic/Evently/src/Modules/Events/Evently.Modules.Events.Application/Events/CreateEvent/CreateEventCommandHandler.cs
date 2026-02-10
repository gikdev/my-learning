using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Events;
using MediatR;

namespace Evently.Modules.Events.Application.Events.CreateEvent;

internal sealed class CreateEventCommandHandler(
    IEventRepo eventRepo,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand req, CancellationToken cancellationToken)
    {
        var @event = Event.Create(
            endsAtUtc: req.EndsAtUtc,
            startsAtUtc: req.StartsAtUtc,
            location: req.Location,
            description: req.Description,
            title: req.Title
        );

        eventRepo.Insert(@event);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return @event.Id;
    }
}
