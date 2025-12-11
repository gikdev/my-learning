using Domain.Categories;
using ErrorOr;
using MediatR;

namespace App.Categories.Queries.ListCategories;

public record ListCategoriesQuery : IRequest<ErrorOr<IEnumerable<Category>>>;
