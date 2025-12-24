using Newtonsoft.Json;

namespace Builtin;

public class Sth
{
    public string Nothing { get; internal set; }

    [JsonConstructor]
    private Sth(
        string nothing,
        Guid id
    )
    {
        Nothing = nothing;
    }

#pragma warning disable CS8618
    private Sth() { }
#pragma warning restore CS8618

    public string Print()
        => $"Value of nothing is: {Nothing}";
}
