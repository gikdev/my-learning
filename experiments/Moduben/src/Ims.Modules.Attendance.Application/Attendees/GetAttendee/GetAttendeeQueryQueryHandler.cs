using System.Data.Common;
using Dapper;
using Ims.Common.Application.Data;
using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Attendance.Domain.Attendees;

namespace Ims.Modules.Attendance.Application.Attendees.GetAttendee;

internal sealed class GetAttendeeQueryQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetAttendeeQuery, AttendeeResponse> {
    public async Task<Result<AttendeeResponse>> Handle(GetAttendeeQuery request, CancellationToken cancellationToken) {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
            SELECT
                id AS {nameof(AttendeeResponse.Id)},
                email AS {nameof(AttendeeResponse.Email)},
                first_name AS {nameof(AttendeeResponse.FirstName)},
                last_name AS {nameof(AttendeeResponse.LastName)}
            FROM attendance.attendees
            WHERE id = @CustomerId
            """;

        AttendeeResponse? customer = await connection.QuerySingleOrDefaultAsync<AttendeeResponse>(sql, request);

        if (customer is null) {
            return Result.Failure<AttendeeResponse>(AttendeeErrors.NotFound(request.CustomerId));
        }

        return customer;
    }
}
