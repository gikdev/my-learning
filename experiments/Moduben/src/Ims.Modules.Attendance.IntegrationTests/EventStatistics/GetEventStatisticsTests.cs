using FluentAssertions;
using Ims.Common.Domain;
using Ims.Modules.Attendance.Application.EventStatistics.GetEventStatistics;
using Ims.Modules.Attendance.Domain.Events;
using Ims.Modules.Attendance.IntegrationTests.Abstractions;

namespace Ims.Modules.Attendance.IntegrationTests.EventStatistics;

public class GetEventStatisticsTests : BaseIntegrationTest {
    public GetEventStatisticsTests(IntegrationTestWebAppFactory factory)
        : base(factory) { }

    [Fact]
    public async Task Should_ReturnFailure_WhenEventStatisticsDoesNotExist() {
        // Arrange
        var query = new GetEventStatisticsQuery(Guid.NewGuid());

        // Act
        Result<EventStatisticsResponse> result = await Sender.Send(query);

        // Assert
        result.Error.Should().Be(EventErrors.NotFound(query.EventId));
    }
}
