using App.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace App.Todos.Commands.RenameTodo;

public class RenameTodoCommandHandler(
    ITodosRepository todosRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<RenameTodoCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>> Handle(RenameTodoCommand request, CancellationToken cancellationToken) {
        var todo = await todosRepository.GetByIdAsync(request.TodoId);
        if (todo is null) return Error.NotFound(description: "Todo not found");

        todo.Rename(request.NewTitle);

        await todosRepository.UpdateAsync(todo);
        await unitOfWork.CommitChangesAsync();

        return Result.Success;
    }
}
