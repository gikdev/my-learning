using MediatR;
using TaskForge.Domain.LabelAggregate;

namespace TaskForge.Application.Labels.Queries.ListLabels;

public record ListLabelsQuery : IRequest<IEnumerable<Label>>;
