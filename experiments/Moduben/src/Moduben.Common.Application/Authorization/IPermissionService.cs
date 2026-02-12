using Moduben.Common.Domain;

namespace Moduben.Common.Application.Authorization;

public interface IPermissionService {
    Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
}
