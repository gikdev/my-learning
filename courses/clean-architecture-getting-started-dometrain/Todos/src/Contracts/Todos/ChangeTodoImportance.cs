namespace Contracts.Todos;

public record ChangeTodoImportanceRequest {
    public required TodoImportance Importance { get; init; }
}
