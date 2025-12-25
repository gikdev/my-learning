using Bahrami85Api;
using Bahrami85Api.Core;
using NUnit.Framework;

namespace Bahrami85Api.Test.Unit.MockServer;

[TestFixture]
public class ListMenuTabsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "name": "name",
                  "order": 1,
                  "description": "description"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/menus/menuId/tabs")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MenuTabs.ListMenuTabsAsync(
            new ListMenuTabsRequest { MenuId = "menuId" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<MenuTabListResponse>(mockResponse)).UsingDefaults()
        );
    }
}
