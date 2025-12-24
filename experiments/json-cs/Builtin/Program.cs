using Newtonsoft.Json;

namespace Builtin;

public class Program
{
    public static void Main()
    {
        var json = File.ReadAllText("./input.json");

        var settings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            MissingMemberHandling = MissingMemberHandling.Ignore,
        };

        var result = JsonConvert.DeserializeObject<Sth>(json, settings);
        // var result = JsonSerializer.Deserialize<Sth>(json);

        Console.WriteLine(result?.Print());
    }
}
