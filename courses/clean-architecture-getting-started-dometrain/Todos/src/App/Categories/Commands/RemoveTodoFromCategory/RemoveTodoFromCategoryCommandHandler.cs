using App.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace App.Categories.Commands.RemoveTodoFromCategory;

public class RemoveTodoFromCategoryCommandHandler(
    ITodosRepository todosRepository,
    ICategoriesRepository categoriesRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<RemoveTodoFromCategoryCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>> Handle(
        RemoveTodoFromCategoryCommand request,
        CancellationToken cancellationToken
    ) {
        var todo = await todosRepository.GetByIdAsync(request.TodoId);
        if (todo is null) return Error.NotFound(description: "Todo not found");

        var category = await categoriesRepository.GetByIdAsync(request.CategoryId);
        if (category is null) return Error.NotFound(description: "Category not found");

        category.RemoveTodo(todo);

        await categoriesRepository.UpdateAsync(category);
        await todosRepository.UpdateAsync(todo);
        await unitOfWork.CommitChangesAsync();

        return Result.Success;
    }
}
