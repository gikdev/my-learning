using Bahrami85Api;
using Bahrami85Api.Core;
using NUnit.Framework;

namespace Bahrami85Api.Test.Unit.MockServer;

[TestFixture]
public class CreateMenuTabTest : BaseMockServerTest
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
              "description": "description"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/menus/menuId/tabs")
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

        var response = await Client.MenuTabs.CreateMenuTabAsync(
            new CreateMenuTabRequest
            {
                MenuId = "menuId",
                Name = "name",
                Order = 1,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<MenuTabItselfResponse>(mockResponse)).UsingDefaults()
        );
    }
}
