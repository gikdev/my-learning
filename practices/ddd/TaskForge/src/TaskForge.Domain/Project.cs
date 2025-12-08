using TaskForge.Domain.Common;

namespace TaskForge.Domain;

public class Project : Entity {
    private readonly string _title;
    private readonly ProjectStatus _status;

    public Project(
        string title,
        ProjectStatus? status = null,
        Guid? id = null
    ) : base(id ?? Guid.NewGuid()) {
        _title = title;
        _status = status ?? ProjectStatus.Active;
    }
}
