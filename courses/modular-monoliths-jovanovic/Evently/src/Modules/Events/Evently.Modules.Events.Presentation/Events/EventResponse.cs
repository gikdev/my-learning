namespace Evently.Modules.Events.Presentation.Events;

internal sealed record EventResponse
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string Location { get; init; }
    public required DateTime StartsAtUtc { get; init; }
    public required DateTime? EndsAtUtc { get; init; }
}
