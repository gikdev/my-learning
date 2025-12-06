using ErrorOr;
using MediatR;

namespace App.Categories.Commands.RemoveTodoFromCategory;

public record RemoveTodoFromCategoryCommand(Guid CategoryId, Guid TodoId) : IRequest<ErrorOr<Success>>;
