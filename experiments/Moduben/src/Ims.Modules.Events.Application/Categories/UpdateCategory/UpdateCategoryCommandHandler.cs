using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Events.Application.Abstractions.Data;
using Ims.Modules.Events.Domain.Categories;

namespace Ims.Modules.Events.Application.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCategoryCommand> {
    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken) {
        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        if (category is null) {
            return Result.Failure(CategoryErrors.NotFound(request.CategoryId));
        }

        category.ChangeName(request.Name);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
