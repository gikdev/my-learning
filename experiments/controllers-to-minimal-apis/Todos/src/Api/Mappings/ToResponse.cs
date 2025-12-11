using Contracts.Categories;
using Contracts.Todos;
using Domain.Categories;
using Domain.Todos;

namespace Api.Mappings;

public static class ToResponse {
    public static TodoResponse MapToResponse(this Todo todo) => new() {
        Id = todo.Id,
        Title = todo.Title,
        Importance = todo.Importance.ToNativeEnum(),
        IsCompleted = todo.IsCompleted,
    };

    public static CategoryResponse MapToResponse(this Category category) => new() {
        Id = category.Id,
        Title = category.Title,
    };
}
