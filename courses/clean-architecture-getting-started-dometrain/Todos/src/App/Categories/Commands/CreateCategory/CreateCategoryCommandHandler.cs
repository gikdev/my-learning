using App.Common.Interfaces;
using Domain.Categories;
using ErrorOr;
using MediatR;

namespace App.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(
    ICategoriesRepository categoriesRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<CreateCategoryCommand, ErrorOr<Category>> {
    public async Task<ErrorOr<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken) {
        var newCategory = new Category(request.Title);
        await categoriesRepository.AddAsync(newCategory);
        await unitOfWork.CommitChangesAsync();
        return newCategory;
    }
}
