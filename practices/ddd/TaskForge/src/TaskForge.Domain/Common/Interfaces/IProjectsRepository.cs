using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Domain.ProjectAggregate;

namespace TaskForge.Domain.Common.Interfaces;

public interface IProjectsRepository {
    Task<bool> ExistsWithTitleAsync(NonEmptyTitle title, Guid? excludeProjectId = null);
    Task<Project?> GetByIdAsync(Guid projectId);
    Task<List<Project>> GetAllAsync();
}
