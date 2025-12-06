using ErrorOr;
using MediatR;

namespace App.Categories.Commands.RenameCategory;

public class RenameCategoryCommandHandler : IRequestHandler<RenameCategoryCommand, ErrorOr<Success>> {
    public Task<ErrorOr<Success>> Handle(RenameCategoryCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}

