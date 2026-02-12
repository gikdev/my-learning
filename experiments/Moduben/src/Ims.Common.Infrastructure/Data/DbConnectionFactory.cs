using System.Data.Common;
using Ims.Common.Application.Data;
using Npgsql;

namespace Ims.Common.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory {
    public async ValueTask<DbConnection> OpenConnectionAsync() {
        return await dataSource.OpenConnectionAsync();
    }
}
