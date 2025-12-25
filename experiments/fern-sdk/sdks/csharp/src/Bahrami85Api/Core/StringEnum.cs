using System.Text.Json.Serialization;

namespace Bahrami85Api.Core;

public interface IStringEnum : IEquatable<string>
{
    public string Value { get; }
}
