using App.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace App.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandHandler(
    ITodosRepository todosRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<UpdateTodoCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken) {
        var todo = await todosRepository.GetByIdAsync(request.TodoId);
        if (todo is null)
            return Error.NotFound(description: "Todo not found");

        // Rename
        if (request.NewTitle is not null)
            todo.Rename(request.NewTitle);

        // Change importance
        if (request.Importance is not null) {
            var result = todo.ChangeImportance(request.Importance);

            if (result.IsError)
                return result.Errors;
        }

        // Toggle completed
        if (request.Completed is not null)
            todo.ToggleCompleted(request.Completed.Value);

        await todosRepository.UpdateAsync(todo);
        await unitOfWork.CommitChangesAsync();

        return Result.Success;
    }
}
