using System.Data.Common;

namespace Moduben.Common.Application.Data;

public interface IDbConnectionFactory {
    ValueTask<DbConnection> OpenConnectionAsync();
}
