using ErrorOr;
using MediatR;

namespace App.Todos.Commands.ChangeTodoImportance;

public class ChangeTodoImportanceCommandHandler : IRequestHandler<ChangeTodoImportanceCommand, ErrorOr<Success>> {
    public Task<ErrorOr<Success>> Handle(ChangeTodoImportanceCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
