using System.Text.Json.Serialization;
using Bahrami85Api.Core;

namespace Bahrami85Api;

[Serializable]
public record ListMenuTabsRequest
{
    [JsonIgnore]
    public required string MenuId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
