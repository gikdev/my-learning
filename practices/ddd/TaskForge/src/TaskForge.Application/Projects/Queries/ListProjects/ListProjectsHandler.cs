using MediatR;
using TaskForge.Domain.Common.Interfaces;
using DomainProject = TaskForge.Domain.ProjectAggregate.Project;

namespace TaskForge.Application.Projects.Queries.ListProjects;

public class ListProjectsHandler(
    IProjectsRepository projectsRepository
) : IRequestHandler<ListProjectsQuery, IEnumerable<DomainProject>> {
    public async Task<IEnumerable<DomainProject>> Handle(
        ListProjectsQuery request,
        CancellationToken cancellationToken
    ) {
        var projects = await projectsRepository.GetAllAsync();
        return projects;
    }
}
