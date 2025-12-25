using System.Text.Json.Serialization;
using Bahrami85Api.Core;

namespace Bahrami85Api;

[Serializable]
public record CreateMenuRequest
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
