using System.Text.Json.Serialization;

namespace TaskForge.Contracts.Projects;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProjectStatus {
    Active = 0,
    Completed = 1,
}
