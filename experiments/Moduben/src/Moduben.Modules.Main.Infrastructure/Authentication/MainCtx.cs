using Moduben.Common.Application.Exceptions;
using Moduben.Common.Infrastructure.Authentication;
using Moduben.Modules.Main.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

namespace Moduben.Modules.Main.Infrastructure.Authentication;

internal sealed class MainCtx(IHttpContextAccessor httpContextAccessor) : IMainCtx {
    public Guid UserId => httpContextAccessor.HttpContext?.User.GetUserId() ??
                              throw new ModubenException("User identifier is unavailable");
}
