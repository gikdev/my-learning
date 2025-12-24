namespace Builtin;

public sealed record ParentDto
{
    public required string Nothing { get; init; }
    public required List<ChildDto> Children { get; init; }
}
