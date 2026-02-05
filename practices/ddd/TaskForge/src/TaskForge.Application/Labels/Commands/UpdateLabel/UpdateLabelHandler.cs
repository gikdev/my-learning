using ErrorOr;
using MediatR;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.Services;

namespace TaskForge.Application.Labels.Commands.UpdateLabel;

public class UpdateLabelHandler(
    ILabelsRepository labelsRepository
) : IRequestHandler<UpdateLabelCommand, ErrorOr<Success>> {
    public async Task<ErrorOr<Success>> Handle(
        UpdateLabelCommand request,
        CancellationToken cancellationToken
    ) {
        var result = await new LabelService(labelsRepository).RenameLabelAsync(
            request.Id,
            request.NewTitle
        );

        if (result.IsError) return result.Errors;
        var label = result.Value;

        await labelsRepository.UpdateAsync(label);

        return Result.Success;
    }
}
