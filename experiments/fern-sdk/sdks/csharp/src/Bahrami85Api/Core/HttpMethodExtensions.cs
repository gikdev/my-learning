using System.Net.Http;

namespace Bahrami85Api.Core;

internal static class HttpMethodExtensions
{
    public static readonly HttpMethod Patch = new("PATCH");
}
