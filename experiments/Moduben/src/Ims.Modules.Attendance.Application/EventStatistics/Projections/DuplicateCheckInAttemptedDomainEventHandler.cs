using System.Data.Common;
using Dapper;
using Ims.Common.Application.Data;
using Ims.Common.Application.Messaging;
using Ims.Modules.Attendance.Domain.Attendees;

namespace Ims.Modules.Attendance.Application.EventStatistics.Projections;

internal sealed class DuplicateCheckInAttemptedDomainEventHandler(IDbConnectionFactory dbConnectionFactory)
    : DomainEventHandler<DuplicateCheckInAttemptedDomainEvent> {
    public override async Task Handle(
        DuplicateCheckInAttemptedDomainEvent domainEvent,
        CancellationToken                    cancellationToken = default
    ) {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            """
            UPDATE attendance.event_statistics es
            SET duplicate_check_in_tickets = array_append(duplicate_check_in_tickets, @TicketCode)
            WHERE es.event_id = @EventId
            """;

        await connection.ExecuteAsync(sql, domainEvent);
    }
}
