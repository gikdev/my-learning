using Domain.Todos;
using ErrorOr;
using MediatR;

namespace App.Todos.Queries.ListTodos;

public record ListTodosQuery() : IRequest<ErrorOr<IEnumerable<Todo>>>;
