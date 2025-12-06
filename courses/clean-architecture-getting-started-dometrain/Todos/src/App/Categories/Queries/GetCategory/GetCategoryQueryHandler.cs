using App.Common.Interfaces;
using Domain.Categories;
using ErrorOr;
using MediatR;

namespace App.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler(
    ICategoriesRepository categoriesRepository
) : IRequestHandler<GetCategoryQuery, ErrorOr<Category>> {
    public async Task<ErrorOr<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken) {
        var category = await categoriesRepository.GetByIdAsync(request.CategoryId);
        if (category is null) return Error.NotFound(description: "Category not found");

        return category;
    }
}
