using Ims.Common.Application.Authorization;
using Ims.Common.Domain;
using Ims.Modules.Users.Application.Users.GetUserPermissions;
using MediatR;

namespace Ims.Modules.Users.Infrastructure.Authorization;

internal sealed class PermissionService(ISender sender) : IPermissionService {
    public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId) {
        return await sender.Send(new GetUserPermissionsQuery(identityId));
    }
}
