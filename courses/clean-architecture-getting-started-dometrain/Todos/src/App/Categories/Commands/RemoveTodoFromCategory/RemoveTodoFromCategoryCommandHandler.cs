using ErrorOr;
using MediatR;

namespace App.Categories.Commands.RemoveTodoFromCategory;

public class RemoveTodoFromCategoryCommandHandler : IRequestHandler<RemoveTodoFromCategoryCommand, ErrorOr<Success>> {
    public Task<ErrorOr<Success>> Handle(RemoveTodoFromCategoryCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
