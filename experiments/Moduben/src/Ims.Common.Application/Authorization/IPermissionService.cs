using Ims.Common.Domain;

namespace Ims.Common.Application.Authorization;

public interface IPermissionService {
    Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
}
