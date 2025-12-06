namespace Contracts.Todos;

public record TodoResponse {
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required TodoImportance Importance { get; init; }
    public required bool IsCompleted { get; init; }
}
