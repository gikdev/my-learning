using App.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace App.Categories.Commands.RenameCategory;

public class RenameCategoryCommandHandler(
    ICategoriesRepository categoriesRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<RenameCategoryCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>> Handle(RenameCategoryCommand request, CancellationToken cancellationToken) {
        var category = await categoriesRepository.GetByIdAsync(request.CategoryId);
        if (category == null) return Error.NotFound(description: "Category not found");

        category.Rename(request.NewTitle);

        await categoriesRepository.UpdateAsync(category);
        await unitOfWork.CommitChangesAsync();

        return Result.Success;
    }
}
