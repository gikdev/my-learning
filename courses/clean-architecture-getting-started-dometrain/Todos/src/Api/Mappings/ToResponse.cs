using Contracts.Todos;
using Domain.Todos;

namespace Api.Mappings;

public static class ToResponse {
    public static TodoResponse MapToResponse(this Todo todo) => new() {
        Id = todo.Id,
        Title = todo.Title,
        Importance = todo.Importance.ToNativeEnum(),
        IsCompleted = todo.IsCompleted,
    };
}
