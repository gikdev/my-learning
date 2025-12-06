using ErrorOr;
using MediatR;

namespace App.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ErrorOr<Success>> {
    public Task<ErrorOr<Success>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
