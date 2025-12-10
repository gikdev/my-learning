namespace TaskForge.Contracts.Labels;

public record LabelResponse {
    public required Guid Id { get; init; }
    public required string Title { get; init; }
}
