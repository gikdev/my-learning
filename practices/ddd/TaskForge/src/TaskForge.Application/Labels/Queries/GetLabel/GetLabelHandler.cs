using ErrorOr;
using MediatR;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.LabelAggregate;

namespace TaskForge.Application.Labels.Queries.GetLabel;

public class GetLabelHandler(
    ILabelsRepository labelsRepository
) : IRequestHandler<GetLabelQuery, ErrorOr<Label>> {
    public async Task<ErrorOr<Label>> Handle(
        GetLabelQuery request,
        CancellationToken cancellationToken
    ) {
        var label = await labelsRepository.GetByIdAsync(request.Id);
        if (label is null) return Error.NotFound(description: "Label not found");

        return label;
    }
}
