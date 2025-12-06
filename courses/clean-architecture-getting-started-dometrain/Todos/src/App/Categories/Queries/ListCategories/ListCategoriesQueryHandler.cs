using Domain.Categories;
using ErrorOr;
using MediatR;

namespace App.Categories.Queries.ListCategories;

public class ListCategoriesQueryHandler : IRequestHandler<ListCategoriesQuery, ErrorOr<IEnumerable<Category>>> {
    public Task<ErrorOr<IEnumerable<Category>>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
