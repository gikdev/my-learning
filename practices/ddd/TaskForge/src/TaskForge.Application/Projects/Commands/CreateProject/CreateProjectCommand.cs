using ErrorOr;
using MediatR;
using TaskForge.Domain.ProjectAggregate;

namespace TaskForge.Application.Projects.Commands.CreateProject;

public record CreateProjectCommand(
    string Title,
    ProjectStatus? Status = null
) : IRequest<ErrorOr<Project>>;
