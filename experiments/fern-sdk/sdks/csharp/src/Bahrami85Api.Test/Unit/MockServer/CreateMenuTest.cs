using Bahrami85Api;
using Bahrami85Api.Core;
using NUnit.Framework;

namespace Bahrami85Api.Test.Unit.MockServer;

[TestFixture]
public class CreateMenuTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name"
            }
            """;

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
                    .WithPath("/api/menus")
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

        var response = await Client.Menus.CreateMenuAsync(new CreateMenuRequest { Name = "name" });
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<MenuItselfResponse>(mockResponse)).UsingDefaults()
        );
    }
}
