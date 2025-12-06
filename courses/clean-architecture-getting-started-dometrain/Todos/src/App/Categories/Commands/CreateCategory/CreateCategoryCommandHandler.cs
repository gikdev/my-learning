using ErrorOr;
using MediatR;

namespace App.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<Success>> {
    public Task<ErrorOr<Success>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
