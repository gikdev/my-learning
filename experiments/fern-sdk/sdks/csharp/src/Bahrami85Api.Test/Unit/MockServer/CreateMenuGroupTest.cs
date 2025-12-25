using Bahrami85Api;
using Bahrami85Api.Core;
using NUnit.Framework;

namespace Bahrami85Api.Test.Unit.MockServer;

[TestFixture]
public class CreateMenuGroupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name",
              "order": 1
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "order": 1,
              "description": "description",
              "imageUrl": "imageUrl"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/menus/menuId/tabs/menuTabId/groups")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MenuGroups.CreateMenuGroupAsync(
            new CreateMenuGroupRequest
            {
                MenuId = "menuId",
                MenuTabId = "menuTabId",
                Name = "name",
                Order = 1,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<MenuGroupItselfResponse>(mockResponse)).UsingDefaults()
        );
    }
}
