using MediatR;

namespace Evently.Modules.Events.Application.Events.CreateEvent;

public sealed record CreateEventCommand : IRequest<Guid>
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string Location { get; init; }
    public required DateTime StartsAtUtc { get; init; }
    public required DateTime? EndsAtUtc { get; init; }
};
