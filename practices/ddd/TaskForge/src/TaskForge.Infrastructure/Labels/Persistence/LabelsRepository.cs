using ErrorOr;
using Microsoft.EntityFrameworkCore;
using TaskForge.Domain.Common.Interfaces;
using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Domain.LabelAggregate;
using TaskForge.Infrastructure.Common.Persistence;

namespace TaskForge.Infrastructure.Labels.Persistence;

public class LabelsRepository(
    TaskForgeDbContext db
) : ILabelsRepository {
    public async Task AddAsync(Label label) {
        await db.Labels.AddAsync(label);
        await db.SaveChangesAsync();
    }

    public async Task<bool> ExistsWithTitleAsync(NonEmptyTitle title, Guid? existingLabelId = null) {
        return await db.Labels
            .AnyAsync(l =>
                l.Title.Value == title.Value &&
                (existingLabelId == null || l.Id != existingLabelId)
            );
    }


    public async Task<List<Label>> GetAllAsync() {
        var labels = await db.Labels.ToListAsync();
        return labels;
    }

    public async Task<Label?> GetByIdAsync(Guid labelId) {
        var label = await db.Labels.FirstOrDefaultAsync(l => l.Id == labelId);
        return label;
    }

    public async Task<ErrorOr<Success>> RemoveByIdAsync(Guid labelId) {
        var label = await db.Labels.FirstOrDefaultAsync(l => l.Id == labelId);
        if (label is null) return Error.NotFound("Label not found");

        db.Remove(label);
        await db.SaveChangesAsync();

        return Result.Success;
    }

    public async Task UpdateAsync(Label label) {
        db.Update(label);
        await db.SaveChangesAsync();
    }
}
