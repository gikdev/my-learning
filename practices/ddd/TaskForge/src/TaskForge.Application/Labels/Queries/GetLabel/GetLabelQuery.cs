using ErrorOr;
using MediatR;
using TaskForge.Domain.LabelAggregate;

namespace TaskForge.Application.Labels.Queries.GetLabel;

public record GetLabelQuery(
    Guid Id
): IRequest<ErrorOr<Label>>;
