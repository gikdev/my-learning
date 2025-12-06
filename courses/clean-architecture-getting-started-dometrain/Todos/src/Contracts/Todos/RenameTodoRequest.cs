using System.ComponentModel.DataAnnotations;

namespace Contracts.Todos;

public record RenameTodoRequest {
    [MinLength(1)]
    public required string NewTitle { get; init; }
}
