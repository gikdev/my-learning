using System.ComponentModel.DataAnnotations;

namespace Contracts.Todos;

public class UpdateTodoRequest {
    [MinLength(1)]
    public string? NewTitle { get; set; }

    public TodoImportance? Importance { get; set; }
    public bool? Completed { get; set; }
}
