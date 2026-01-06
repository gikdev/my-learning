using ErrorOr;
using MediatR;
using TaskForge.Domain.LabelAggregate;

namespace TaskForge.Application.Labels.Commands.CreateLabel;

public record CreateLabelCommand(
    string Title
) : IRequest<ErrorOr<Label>>;
