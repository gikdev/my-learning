using Domain.Categories;
using ErrorOr;
using MediatR;

namespace App.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Title) : IRequest<ErrorOr<Category>>;
