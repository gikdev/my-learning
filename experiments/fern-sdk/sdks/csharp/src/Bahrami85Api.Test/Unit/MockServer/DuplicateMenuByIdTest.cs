using Bahrami85Api;
using Bahrami85Api.Core;
using NUnit.Framework;

namespace Bahrami85Api.Test.Unit.MockServer;

[TestFixture]
public class DuplicateMenuByIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "description": "description"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/menus/menuId/duplicates")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Menus.DuplicateMenuByIdAsync(
            new DuplicateMenuByIdRequest { MenuId = "menuId" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<MenuItselfResponse>(mockResponse)).UsingDefaults()
        );
    }
}
