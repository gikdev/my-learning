using TaskForge.Domain.Common;

namespace TaskForge.Domain;

public class Label : Entity {
    private readonly string _title;

    public Label(
        string title,
        Guid? id = null
    ) : base(id ?? Guid.NewGuid()) {
        _title = title;
    }
}
