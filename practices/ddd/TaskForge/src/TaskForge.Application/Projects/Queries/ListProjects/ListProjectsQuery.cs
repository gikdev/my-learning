using MediatR;
using DomainProject = TaskForge.Domain.ProjectAggregate.Project;

namespace TaskForge.Application.Projects.Queries.ListProjects;

public record ListProjectsQuery : IRequest<IEnumerable<DomainProject>>;
