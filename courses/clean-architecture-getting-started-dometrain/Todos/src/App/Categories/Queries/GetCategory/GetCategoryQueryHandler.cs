using Domain.Categories;
using ErrorOr;
using MediatR;

namespace App.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, ErrorOr<Category>> {
    public Task<ErrorOr<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
