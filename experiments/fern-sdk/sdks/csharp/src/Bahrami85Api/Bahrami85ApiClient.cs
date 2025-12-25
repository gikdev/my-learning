using Bahrami85Api.Core;

namespace Bahrami85Api;

public partial class Bahrami85ApiClient
{
    private readonly RawClient _client;

    public Bahrami85ApiClient(ClientOptions? clientOptions = null)
    {
        var defaultHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Bahrami85Api" },
                { "X-Fern-SDK-Version", Version.Current },
            }
        );
        clientOptions ??= new ClientOptions();
        foreach (var header in defaultHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        _client = new RawClient(clientOptions);
        MenuTabs = new MenuTabsClient(_client);
        Menus = new MenusClient(_client);
        MenuGroups = new MenuGroupsClient(_client);
    }

    public MenuTabsClient MenuTabs { get; }

    public MenusClient Menus { get; }

    public MenuGroupsClient MenuGroups { get; }
}
