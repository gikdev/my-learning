using Newtonsoft.Json;

namespace Builtin;

public class Parent
{
    public string Nothing { get; private set; }
    private readonly List<Child> _children = [];
    public IReadOnlyCollection<Child> Children => _children;

    private Parent(
        string nothing,
        Guid id
    )
    {
        Nothing = nothing;
    }

    public static Parent Create(string name)
    {
        return new Parent(name, Guid.NewGuid());
    }

#pragma warning disable CS8618
    private Parent() { }
#pragma warning restore CS8618

    public void AddChild(string name)
    {
        _children.Add(Child.Create(name));
    }

    public string Print()
        => $"Value of nothing is: {Nothing} & count: {_children.Count}";
}
