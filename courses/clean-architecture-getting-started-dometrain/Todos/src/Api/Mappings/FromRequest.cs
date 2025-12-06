using App.Todos.Queries.ListTodos;
using Contracts.Todos;

namespace Api.Mappings;

public static class FromRequest {
    public static ListTodosQuery MapToQuery(this ListTodosRequest request) => new() {
        CategoryId = request.CategoryId,
        IsCompleted = request.IsCompleted,
        Importance = request.Importance?.ToSmartEnum(),
        SearchQuery = request.SearchQuery,
    };
}
