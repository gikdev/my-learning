using ErrorOr;
using MediatR;

namespace App.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(Guid CategoryId) : IRequest<ErrorOr<Success>>;
