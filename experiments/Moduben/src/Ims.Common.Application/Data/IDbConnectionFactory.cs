using System.Data.Common;

namespace Ims.Common.Application.Data;

public interface IDbConnectionFactory {
    ValueTask<DbConnection> OpenConnectionAsync();
}
