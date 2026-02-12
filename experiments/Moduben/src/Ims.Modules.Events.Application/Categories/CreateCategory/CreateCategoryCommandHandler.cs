using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Events.Application.Abstractions.Data;
using Ims.Modules.Events.Domain.Categories;

namespace Ims.Modules.Events.Application.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, Guid> {
    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken) {
        var category = Category.Create(request.Name);

        categoryRepository.Insert(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
