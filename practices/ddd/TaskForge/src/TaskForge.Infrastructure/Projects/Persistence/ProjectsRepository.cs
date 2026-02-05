using Microsoft.EntityFrameworkCore;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Infrastructure.Common.Persistence;
using DomainProject = TaskForge.Domain.ProjectAggregate.Project;

namespace TaskForge.Infrastructure.Projects.Persistence;

public class ProjectsRepository(
    TaskForgeDbContext db
) : IProjectsRepository {
    public async Task AddAsync(DomainProject project) {
        await db.Projects.AddAsync(project);
        await db.SaveChangesAsync();
    }

    public async Task<bool> ExistsWithTitleAsync(NonEmptyTitle title, Guid? excludeProjectId = null) {
        return await db.Projects
            .AnyAsync(p =>
                p.Title.Value == title.Value &&
                (excludeProjectId == null || p.Id != excludeProjectId)
            );
    }

    public async Task<List<DomainProject>> GetAllAsync() {
        return await db.Projects.ToListAsync();
    }

    public async Task<DomainProject?> GetByIdAsync(Guid projectId) {
        return await db.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
    }
}
