using ErrorOr;
using MediatR;

namespace App.Todos.Commands.RenameTodo;

public class RenameTodoCommandHandler : IRequestHandler<RenameTodoCommand, ErrorOr<Success>> {
    public Task<ErrorOr<Success>> Handle(RenameTodoCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}

