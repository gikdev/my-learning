using ErrorOr;
using MediatR;

namespace TaskForge.Application.Labels.Commands.DeleteLabel;

public record DeleteLabelCommand(
    Guid Id
) : IRequest<ErrorOr<Success>>;
