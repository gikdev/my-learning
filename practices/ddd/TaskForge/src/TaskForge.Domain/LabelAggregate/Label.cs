using TaskForge.Domain.Common;
using TaskForge.Domain.Common.ValueObjects;

namespace TaskForge.Domain.LabelAggregate;

public class Label : AggregateRoot {
    internal Label(
        NonEmptyTitle title,
        Guid? id = null
    ) : base(id ?? Guid.NewGuid()) {
        Title = title;
    }

    public NonEmptyTitle Title { get; private set; }

    internal void Rename(NonEmptyTitle title) {
        Title = title;
    }
}
