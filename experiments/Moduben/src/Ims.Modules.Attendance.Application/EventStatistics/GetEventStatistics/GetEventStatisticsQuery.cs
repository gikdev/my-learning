using Ims.Common.Application.Messaging;

namespace Ims.Modules.Attendance.Application.EventStatistics.GetEventStatistics;

public sealed record GetEventStatisticsQuery(Guid EventId) : IQuery<EventStatisticsResponse>;
