using ErrorOr;
using MediatR;
using TaskForge.Domain.Common.Interfaces;

namespace TaskForge.Application.Labels.Commands.DeleteLabel;

public class DeleteLabelHandler(
    ILabelsRepository labelsRepository
) : IRequestHandler<DeleteLabelCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>> Handle(
        DeleteLabelCommand request,
        CancellationToken cancellationToken
    ) {
        var result = await labelsRepository.RemoveByIdAsync(request.Id);

        if (result.IsError) return result.Errors;

        return Result.Success;
    }
}
