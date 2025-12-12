using ErrorOr;
using MediatR;

namespace TaskForge.Application.Labels.Commands.UpdateLabel;

public record UpdateLabelCommand(
    Guid Id,
    string NewTitle
) : IRequest<ErrorOr<Success>>;
