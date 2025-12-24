using Newtonsoft.Json;

namespace Builtin;

public class Program
{
    private static readonly JsonSerializerSettings _jsonSettings = new()
    {
        ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        MissingMemberHandling = MissingMemberHandling.Ignore,
    };

    public static void Main()
    {
        ParentAndChildReadingExample();
    }

    public static void ChildAndParentExample()
    {
        var sth = Parent.Create("Some Sth");
        sth.AddChild("Child 1");
        sth.AddChild("Child 2");

        var json = JsonConvert.SerializeObject(sth);
        File.WriteAllText("./parent.json", json);
    }

    public static void ParentAndChildReadingExample()
    {
        var json = File.ReadAllText("./parent.json");

        var result = JsonConvert.DeserializeObject<Parent>(json, _jsonSettings);

        Console.WriteLine(result?.Print());
        // Console.WriteLine($"count: {result?.Children.Count}");
    }

    public static void SimpleReadingExample()
    {
        var json = File.ReadAllText("./input.json");

        var result = JsonConvert.DeserializeObject<Parent>(json, _jsonSettings);

        Console.WriteLine(result?.Print());
    }
}
