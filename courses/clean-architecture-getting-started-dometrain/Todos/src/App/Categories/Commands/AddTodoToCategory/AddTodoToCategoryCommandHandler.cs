using App.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace App.Categories.Commands.AddTodoToCategory;

public class AddTodoToCategoryCommandHandler(
    ITodosRepository todosRepository,
    ICategoriesRepository categoriesRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<AddTodoToCategoryCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>> Handle(AddTodoToCategoryCommand request, CancellationToken cancellationToken) {
        var todo = await todosRepository.GetByIdAsync(request.TodoId);
        if (todo is null) return Error.NotFound(description: "Todo not found");

        var category = await categoriesRepository.GetByIdAsync(request.CategoryId);
        if (category is null) return Error.NotFound(description: "Category not found");

        category.AddTodo(todo);

        await categoriesRepository.UpdateAsync(category);
        await todosRepository.UpdateAsync(todo);
        await unitOfWork.CommitChangesAsync();

        return Result.Success;
    }
}
