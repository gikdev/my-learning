using Domain.Categories;
using ErrorOr;
using MediatR;

namespace App.Categories.Queries.GetCategory;

public record GetCategoryQuery(Guid CategoryId) : IRequest<ErrorOr<Category>>;
