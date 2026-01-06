using ErrorOr;

namespace TaskForge.Domain.Services;

public static class LabelServiceErrors {
    public static readonly Error DuplicateLabelTitle = Error.Conflict(
        "LabelService.DuplicateLabelTitle",
        "Label title must be unique!"
    );

    public static readonly Error LabelNotFound = Error.NotFound(
        "LabelService.LabelNotFound",
        "Label not found!"
    );
}
