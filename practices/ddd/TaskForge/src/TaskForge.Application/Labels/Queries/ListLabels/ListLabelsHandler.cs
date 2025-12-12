using MediatR;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.LabelAggregate;

namespace TaskForge.Application.Labels.Queries.ListLabels;

public class ListLabelsHandler(
    ILabelsRepository labelsRepository
) : IRequestHandler<ListLabelsQuery, IEnumerable<Label>> {
    public async Task<IEnumerable<Label>> Handle(
        ListLabelsQuery request,
        CancellationToken cancellationToken
    ) {
        var labels = await labelsRepository.GetAllAsync();

        return labels;
    }
}
