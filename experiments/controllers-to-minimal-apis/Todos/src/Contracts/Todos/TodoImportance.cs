using System.Text.Json.Serialization;

namespace Contracts.Todos;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TodoImportance {
    Low = 0,
    Medium = 1,
    High = 2,
}
