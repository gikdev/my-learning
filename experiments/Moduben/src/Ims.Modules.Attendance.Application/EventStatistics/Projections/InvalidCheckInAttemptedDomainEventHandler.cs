using System.Data.Common;
using Dapper;
using Ims.Common.Application.Data;
using Ims.Common.Application.Messaging;
using Ims.Modules.Attendance.Domain.Attendees;

namespace Ims.Modules.Attendance.Application.EventStatistics.Projections;

internal sealed class InvalidCheckInAttemptedDomainEventHandler(IDbConnectionFactory dbConnectionFactory)
    : DomainEventHandler<InvalidCheckInAttemptedDomainEvent> {
    public override async Task Handle(
        InvalidCheckInAttemptedDomainEvent domainEvent,
        CancellationToken                  cancellationToken = default
    ) {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            """
            UPDATE attendance.event_statistics es
            SET invalid_check_in_tickets = array_append(invalid_check_in_tickets, @TicketCode)
            WHERE es.event_id = @EventId
            """;

        await connection.ExecuteAsync(sql, domainEvent);
    }
}
