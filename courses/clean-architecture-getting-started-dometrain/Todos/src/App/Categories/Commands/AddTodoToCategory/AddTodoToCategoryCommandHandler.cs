using ErrorOr;
using MediatR;

namespace App.Categories.Commands.AddTodoToCategory;

public class AddTodoToCategoryCommandHandler : IRequestHandler<AddTodoToCategoryCommand, ErrorOr<Success>> {
    public Task<ErrorOr<Success>> Handle(AddTodoToCategoryCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
