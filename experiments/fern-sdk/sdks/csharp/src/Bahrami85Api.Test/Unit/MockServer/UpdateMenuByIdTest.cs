using Bahrami85Api;
using NUnit.Framework;

namespace Bahrami85Api.Test.Unit.MockServer;

[TestFixture]
public class UpdateMenuByIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/menus/menuId")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Menus.UpdateMenuByIdAsync(
                new UpdateMenuRequest { MenuId = "menuId", Name = "name" }
            )
        );
    }
}
