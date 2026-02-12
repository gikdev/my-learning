using Ims.Common.Application.Authorization;
using Ims.Common.Application.Messaging;

namespace Ims.Modules.Users.Application.Users.GetUserPermissions;

public sealed record GetUserPermissionsQuery(string IdentityId) : IQuery<PermissionsResponse>;
