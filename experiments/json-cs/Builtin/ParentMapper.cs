namespace Builtin;

public static class ParentMapper
{
    public static Parent ToDomain(this ParentDto dto)
    {
        var parent = Parent.Create(dto.Nothing);

        foreach (var child in dto.Children)
            parent.AddChild(child.Name);

        return parent;
    }

    public static ParentDto ToDto(this Parent domain)
        => new()
        {
            Nothing = domain.Nothing,
            Children = domain.Children
                .Select(c => new ChildDto { Name = c.Name })
                .ToList()
        };
}
