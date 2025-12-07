using App.Common.Interfaces;
using Domain.Categories;
using ErrorOr;
using MediatR;

namespace App.Categories.Queries.ListCategories;

public class ListCategoriesQueryHandler(
    ICategoriesRepository categoriesRepository
) : IRequestHandler<ListCategoriesQuery, ErrorOr<IEnumerable<Category>>> {
    public async Task<ErrorOr<IEnumerable<Category>>> Handle(
        ListCategoriesQuery request,
        CancellationToken cancellationToken
    ) {
        var categories = await categoriesRepository.ListAsync();
        return categories;
    }
}
