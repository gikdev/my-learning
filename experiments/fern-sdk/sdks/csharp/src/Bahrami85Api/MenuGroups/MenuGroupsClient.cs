using System.Text.Json;
using Bahrami85Api.Core;

namespace Bahrami85Api;

public partial class MenuGroupsClient
{
    private RawClient _client;

    internal MenuGroupsClient(RawClient client)
    {
        _client = client;
    }

    /// <example><code>
    /// await client.MenuGroups.CreateMenuGroupAsync(
    ///     new CreateMenuGroupRequest
    ///     {
    ///         MenuId = "menuId",
    ///         MenuTabId = "menuTabId",
    ///         Name = "name",
    ///         Order = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<MenuGroupItselfResponse> CreateMenuGroupAsync(
        CreateMenuGroupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "api/menus/{0}/tabs/{1}/groups",
                        ValueConvert.ToPathParameterString(request.MenuId),
                        ValueConvert.ToPathParameterString(request.MenuTabId)
                    ),
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<MenuGroupItselfResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new Bahrami85ApiException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new Bahrami85ApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
