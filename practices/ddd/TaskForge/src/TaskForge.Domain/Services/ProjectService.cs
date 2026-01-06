using ErrorOr;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Domain.ProjectAggregate;

namespace TaskForge.Domain.Services;

public class ProjectService(IProjectsRepository projectsRepository) {
    public async Task<ErrorOr<Project>> CreateProjectAsync(
        string rawTitle,
        ProjectStatus? status = null,
        Guid? id = null
    ) {
        var titleOrError = NonEmptyTitle.Create(rawTitle);
        if (titleOrError.IsError) return titleOrError.Errors;

        var exists = await projectsRepository.ExistsWithTitleAsync(titleOrError.Value);
        if (exists) return ProjectServiceErrors.DuplicateProjectTitle;

        return new Project(
            titleOrError.Value,
            status,
            id
        );
    }

    public async Task<ErrorOr<Project>> RenameProjectAsync(Guid projectId, string rawNewTitle) {
        var titleOrError = NonEmptyTitle.Create(rawNewTitle);
        if (titleOrError.IsError)
            return titleOrError.Errors;

        var project = await projectsRepository.GetByIdAsync(projectId);
        if (project is null)
            return ProjectServiceErrors.ProjectNotFound;

        var exists = await projectsRepository.ExistsWithTitleAsync(titleOrError.Value, projectId);
        if (exists)
            return ProjectServiceErrors.DuplicateProjectTitle;

        project.Rename(titleOrError.Value);

        return project;
    }
}
