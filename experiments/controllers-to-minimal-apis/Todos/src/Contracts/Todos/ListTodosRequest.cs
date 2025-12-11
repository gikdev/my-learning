using Microsoft.AspNetCore.Mvc;

namespace Contracts.Todos;

public record ListTodosRequest {
    [FromQuery(Name = "category_id")]
    public Guid? CategoryId { get; init; } = null;

    [FromQuery(Name = "is_completed")]
    public bool? IsCompleted { get; init; } = null;

    [FromQuery(Name = "importance")]
    public TodoImportance? Importance { get; init; } = null;

    [FromQuery(Name = "search_query")]
    public string? SearchQuery { get; init; } = null;
}
