using TaskForge.Domain.Common.ValueObjects;
using TaskForge.Domain.LabelAggregate;

namespace TaskForge.Domain.Common.Interfaces;

public interface ILabelsRepository {
    Task<bool> ExistsWithTitleAsync(NonEmptyTitle title, Guid? existingLabelId = null);
    Task<Label?> GetByIdAsync(Guid labelId);
    Task<List<Label>> GetAllAsync();
}
