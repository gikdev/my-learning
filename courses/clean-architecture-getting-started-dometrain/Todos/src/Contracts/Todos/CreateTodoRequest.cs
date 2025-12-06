using System.ComponentModel.DataAnnotations;

namespace Contracts.Todos;

public record CreateTodoRequest {
    [MinLength(1)]
    public required string Title { get; init; }

    public TodoImportance? Importance { get; init; }
}
