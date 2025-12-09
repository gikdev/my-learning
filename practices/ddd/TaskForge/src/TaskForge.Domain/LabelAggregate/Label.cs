using TaskForge.Domain.Common;
using TaskForge.Domain.Common.ValueObjects;

namespace TaskForge.Domain.LabelAggregate;

public class Label : AggregateRoot {
    private NonEmptyTitle _title;

    internal Label(
        NonEmptyTitle title,
        Guid? id = null
    ) : base(id ?? Guid.NewGuid()) {
        _title = title;
    }

    internal void Rename(NonEmptyTitle title) {
        _title = title;
    }
}
