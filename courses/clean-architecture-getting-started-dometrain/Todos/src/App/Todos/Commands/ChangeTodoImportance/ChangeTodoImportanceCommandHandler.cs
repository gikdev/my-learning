using App.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace App.Todos.Commands.ChangeTodoImportance;

public class ChangeTodoImportanceCommandHandler(
    ITodosRepository todosRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<ChangeTodoImportanceCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>>
        Handle(ChangeTodoImportanceCommand request, CancellationToken cancellationToken) {
        var todo = await todosRepository.GetByIdAsync(request.TodoId);
        if (todo is null) return Error.NotFound(description: "Todo not found");

        todo.ChangeImportance(request.Importance);

        await todosRepository.UpdateAsync(todo);
        await unitOfWork.CommitChangesAsync();

        return Result.Success;
    }
}
