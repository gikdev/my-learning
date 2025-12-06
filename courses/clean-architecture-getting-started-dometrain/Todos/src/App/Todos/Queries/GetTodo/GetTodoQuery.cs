using Domain.Todos;
using ErrorOr;
using MediatR;

namespace App.Todos.Queries.GetTodo;

public record GetTodoQuery(Guid TodoId) : IRequest<ErrorOr<Todo>>;
