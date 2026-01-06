using ErrorOr;
using MediatR;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.LabelAggregate;
using TaskForge.Domain.Services;

namespace TaskForge.Application.Labels.Commands.CreateLabel;

public class CreateLabelHandler(
    ILabelsRepository labelsRepository
) : IRequestHandler<CreateLabelCommand, ErrorOr<Label>> {
    public async Task<ErrorOr<Label>> Handle(
        CreateLabelCommand request,
        CancellationToken cancellationToken
    ) {
        var labelService = new LabelService(labelsRepository);
        var createLabelResult = await labelService.CreateLabelAsync(request.Title);

        if (createLabelResult.IsError) return createLabelResult.Errors;
        var newLabel = createLabelResult.Value;

        await labelsRepository.AddAsync(newLabel);

        return newLabel;
    }
}
