using ErrorOr;

namespace TaskForge.Domain;

public static class ProjectErrors {
    public static readonly Error CantAddTaskWhenProjectIsArchived = Error.Conflict(
        code: "Project.CantAddTaskWhenProjectIsArchived",
        description: "Can not add a new task to an archived project."
    );
}
