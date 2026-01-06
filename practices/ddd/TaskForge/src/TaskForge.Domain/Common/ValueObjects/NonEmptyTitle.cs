using ErrorOr;

namespace TaskForge.Domain.Common.ValueObjects;

public class NonEmptyTitle : ValueObject {
    private NonEmptyTitle(string value) {
        if (string.IsNullOrWhiteSpace(value.Trim()))
            throw new ArgumentException("Value is emtpy!", nameof(value));

        Value = value;
    }

    public string Value { get; init; }

    public static ErrorOr<NonEmptyTitle> Create(string value) {
        if (string.IsNullOrWhiteSpace(value.Trim()))
            return NonEmptyTitleErrors.CannotBeEmpty;

        return new NonEmptyTitle(value);
    }

    public override IEnumerable<object?> GetEqualityComponents() {
        yield return Value;
    }
}
