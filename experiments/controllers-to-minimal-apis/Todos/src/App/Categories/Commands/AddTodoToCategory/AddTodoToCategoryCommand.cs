using ErrorOr;
using MediatR;

namespace App.Categories.Commands.AddTodoToCategory;

public record AddTodoToCategoryCommand(Guid CategoryId, Guid TodoId) : IRequest<ErrorOr<Success>>;
