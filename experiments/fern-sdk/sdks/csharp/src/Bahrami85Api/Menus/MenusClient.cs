using System.Text.Json;
using Bahrami85Api.Core;

namespace Bahrami85Api;

public partial class MenusClient
{
    private RawClient _client;

    internal MenusClient(RawClient client)
    {
        _client = client;
    }

    /// <example><code>
    /// await client.Menus.ListMenusAsync();
    /// </code></example>
    public async Task<MenuListResponse> ListMenusAsync(
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
                    Path = "api/menus",
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
                return JsonUtils.Deserialize<MenuListResponse>(responseBody)!;
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
    /// await client.Menus.CreateMenuAsync(new CreateMenuRequest { Name = "name" });
    /// </code></example>
    public async Task<MenuItselfResponse> CreateMenuAsync(
        CreateMenuRequest request,
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
                    Path = "api/menus",
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
                return JsonUtils.Deserialize<MenuItselfResponse>(responseBody)!;
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
    /// await client.Menus.UpdateMenuByIdAsync(new UpdateMenuRequest { MenuId = "menuId", Name = "name" });
    /// </code></example>
    public async Task UpdateMenuByIdAsync(
        UpdateMenuRequest request,
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
                        "api/menus/{0}",
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

    /// <example><code>
    /// await client.Menus.DeleteMenuByIdAsync(new DeleteMenuByIdRequest { MenuId = "menuId" });
    /// </code></example>
    public async Task DeleteMenuByIdAsync(
        DeleteMenuByIdRequest request,
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
                        "api/menus/{0}",
                        ValueConvert.ToPathParameterString(request.MenuId)
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

    /// <example><code>
    /// await client.Menus.DuplicateMenuByIdAsync(new DuplicateMenuByIdRequest { MenuId = "menuId" });
    /// </code></example>
    public async Task<MenuItselfResponse> DuplicateMenuByIdAsync(
        DuplicateMenuByIdRequest request,
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
                        "api/menus/{0}/duplicates",
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
                return JsonUtils.Deserialize<MenuItselfResponse>(responseBody)!;
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
