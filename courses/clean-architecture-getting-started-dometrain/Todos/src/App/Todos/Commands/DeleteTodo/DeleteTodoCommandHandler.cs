using ErrorOr;
using MediatR;

namespace App.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, ErrorOr<Success>> {
    public Task<ErrorOr<Success>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}

