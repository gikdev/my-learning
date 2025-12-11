using ErrorOr;
using MediatR;

namespace App.Categories.Commands.RenameCategory;

public record RenameCategoryCommand(Guid CategoryId, string NewTitle) : IRequest<ErrorOr<Success>>;
