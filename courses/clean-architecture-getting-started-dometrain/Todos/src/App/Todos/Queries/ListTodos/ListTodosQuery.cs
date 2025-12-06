using Domain.Todos;
using ErrorOr;
using MediatR;

namespace App.Todos.Queries.ListTodos;

public record ListTodosQuery : IRequest<ErrorOr<IEnumerable<Todo>>> {
    public Guid? CategoryId { get; init; }
    public bool? IsCompleted { get; init; }
    public TodoImportance? Importance { get; init; }
    public string? SearchQuery { get; init; }
}
