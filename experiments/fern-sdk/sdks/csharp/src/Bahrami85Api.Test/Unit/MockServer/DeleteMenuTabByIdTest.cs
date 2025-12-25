using Bahrami85Api;
using NUnit.Framework;

namespace Bahrami85Api.Test.Unit.MockServer;

[TestFixture]
public class DeleteMenuTabByIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/api/menus/menuId/tabs/menuTabId")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.MenuTabs.DeleteMenuTabByIdAsync(
                new DeleteMenuTabByIdRequest { MenuId = "menuId", MenuTabId = "menuTabId" }
            )
        );
    }
}
