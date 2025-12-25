using System.Text.Json;
using Bahrami85Api.Core;

namespace Bahrami85Api;

public partial class MenuTabsClient
{
    private RawClient _client;

    internal MenuTabsClient(RawClient client)
    {
        _client = client;
    }

    /// <example><code>
    /// await client.MenuTabs.ListMenuTabsAsync(new ListMenuTabsRequest { MenuId = "menuId" });
    /// </code></example>
    public async Task<MenuTabListResponse> ListMenuTabsAsync(
        ListMenuTabsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "api/menus/{0}/tabs",
                        ValueConvert.ToPathParameterString(request.MenuId)
                    ),
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
                return JsonUtils.Deserialize<MenuTabListResponse>(responseBody)!;
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

    /// <example><code>
    /// await client.MenuTabs.CreateMenuTabAsync(
    ///     new CreateMenuTabRequest
    ///     {
    ///         MenuId = "menuId",
    ///         Name = "name",
    ///         Order = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<MenuTabItselfResponse> CreateMenuTabAsync(
        CreateMenuTabRequest request,
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
                        "api/menus/{0}/tabs",
                        ValueConvert.ToPathParameterString(request.MenuId)
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
                return JsonUtils.Deserialize<MenuTabItselfResponse>(responseBody)!;
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

    /// <example><code>
    /// await client.MenuTabs.UpdateMenuTabByIdAsync(
    ///     new UpdateMenuTabRequest
    ///     {
    ///         MenuId = "menuId",
    ///         MenuTabId = "menuTabId",
    ///         Name = "name",
    ///         Order = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<MenuTabItselfResponse> UpdateMenuTabByIdAsync(
        UpdateMenuTabRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "api/menus/{0}/tabs/{1}",
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
                return JsonUtils.Deserialize<MenuTabItselfResponse>(responseBody)!;
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

    /// <example><code>
    /// await client.MenuTabs.DeleteMenuTabByIdAsync(
    ///     new DeleteMenuTabByIdRequest { MenuId = "menuId", MenuTabId = "menuTabId" }
    /// );
    /// </code></example>
    public async Task DeleteMenuTabByIdAsync(
        DeleteMenuTabByIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "api/menus/{0}/tabs/{1}",
                        ValueConvert.ToPathParameterString(request.MenuId),
                        ValueConvert.ToPathParameterString(request.MenuTabId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            return;
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
