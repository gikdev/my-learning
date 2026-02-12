using Ims.Common.Domain;

namespace Ims.Modules.Events.Domain.Categories;

public sealed class CategoryArchivedDomainEvent(Guid categoryId) : DomainEvent {
    public Guid CategoryId { get; init; } = categoryId;
}
