using App.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace App.Todos.Commands.ToggleTodoCompleted;

public class ToggleTodoCompletedCommandHandler(
    ITodosRepository todosRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<ToggleTodoCompletedCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>>
        Handle(ToggleTodoCompletedCommand request, CancellationToken cancellationToken) {
        var todo = await todosRepository.GetByIdAsync(request.TodoId);
        if (todo is null) return Error.NotFound(description: "Todo not found");

        todo.ToggleCompleted();

        await todosRepository.UpdateAsync(todo);
        await unitOfWork.CommitChangesAsync();

        return Result.Success;
    }
}
