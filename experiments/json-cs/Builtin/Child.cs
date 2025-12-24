using Newtonsoft.Json;

namespace Builtin;

public class Child
{
    public string Name { get; internal set; }

    [JsonConstructor]
    private Child(
        string name,
        Guid id
    )
    {
        Name = name;
    }

    public static Child Create(string name)
    {
        return new Child(name, Guid.NewGuid());
    }

#pragma warning disable CS8618
    private Child() { }
#pragma warning restore CS8618

    public string Print()
        => $"Value of name is: {Name}";
}
