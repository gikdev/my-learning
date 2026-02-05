using TaskForge.Domain.Common.ValueObjects;

namespace TaskForge.Domain.Common.Interfaces;

public interface IProjectsRepository {
    Task<bool> ExistsWithTitleAsync(NonEmptyTitle title, Guid? excludeProjectId = null);
    Task<ProjectAggregate.Project?> GetByIdAsync(Guid projectId);
    Task<List<ProjectAggregate.Project>> GetAllAsync();
    Task AddAsync(ProjectAggregate.Project project);
}
