namespace Contracts.Todos;

public record ListTodosRequest (
    Guid? CategoryId,
    bool? IsCompleted,
    TodoImportance? Importance,
    string? SearchQuery
);
