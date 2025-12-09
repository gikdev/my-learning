using ErrorOr;

namespace TaskForge.Domain.Services;

public static class ProjectServiceErrors {
    public static readonly Error DuplicateProjectTitle = Error.Conflict(
        "ProjectService.DuplicateProjectTitle",
        "Project title must be unique!"
    );

    public static readonly Error ProjectNotFound = Error.NotFound(
        "ProjectService.ProjectNotFound",
        "Project not found!"
    );
}
