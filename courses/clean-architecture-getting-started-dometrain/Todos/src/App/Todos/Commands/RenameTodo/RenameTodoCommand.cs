using ErrorOr;
using MediatR;

namespace App.Todos.Commands.RenameTodo;

public record RenameTodoCommand(Guid TodoId, string NewTitle) : IRequest<ErrorOr<Success>>;
