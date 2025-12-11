using ErrorOr;
using MediatR;

namespace App.Todos.Commands.DeleteTodo;

public record DeleteTodoCommand(Guid TodoId) : IRequest<ErrorOr<Deleted>>;
