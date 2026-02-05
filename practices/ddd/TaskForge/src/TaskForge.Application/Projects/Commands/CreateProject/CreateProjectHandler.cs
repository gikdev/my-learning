using ErrorOr;
using MediatR;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.ProjectAggregate;
using TaskForge.Domain.Services;

namespace TaskForge.Application.Projects.Commands.CreateProject;

public class CreateProjectHandler(
    IProjectsRepository projectsRepository
) : IRequestHandler<CreateProjectCommand, ErrorOr<Project>> {
    public async Task<ErrorOr<Project>> Handle(
        CreateProjectCommand request,
        CancellationToken cancellationToken
    ) {
        var result = await new ProjectService(projectsRepository)
            .CreateProjectAsync(request.Title, request.Status);
        if (result.IsError) return result.Errors;
        var project = result.Value;

        await projectsRepository.AddAsync(project);

        return project;
    }
}
