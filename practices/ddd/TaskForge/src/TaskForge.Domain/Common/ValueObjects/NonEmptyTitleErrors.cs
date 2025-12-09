using ErrorOr;

namespace TaskForge.Domain.Common.ValueObjects;

public static class NonEmptyTitleErrors {
    public static readonly Error CannotBeEmpty = Error.Validation(
        "NonEmptyTitle.CannotBeEmpty",
        "Title can not be empty."
    );
}
