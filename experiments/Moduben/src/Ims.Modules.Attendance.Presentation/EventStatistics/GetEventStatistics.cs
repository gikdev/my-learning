using Ims.Common.Domain;
using Ims.Common.Presentation.Endpoints;
using Ims.Common.Presentation.Results;
using Ims.Modules.Attendance.Application.EventStatistics.GetEventStatistics;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ims.Modules.Attendance.Presentation.EventStatistics;

internal sealed class GetEventStatistics : IEndpoint {
    public void MapEndpoint(IEndpointRouteBuilder app) {
        app.MapGet("event-statistics/{id}", async (Guid id, ISender sender) => {
                Result<EventStatisticsResponse> result = await sender.Send(new GetEventStatisticsQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .RequireAuthorization(Permissions.GetEventStatistics)
            .WithTags(Tags.EventStatistics);
    }
}
