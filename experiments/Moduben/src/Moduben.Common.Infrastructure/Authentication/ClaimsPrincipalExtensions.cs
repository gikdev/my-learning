using System.Security.Claims;
using Moduben.Common.Application.Exceptions;

namespace Moduben.Common.Infrastructure.Authentication;

public static class ClaimsPrincipalExtensions {
    public static Guid GetUserId(this ClaimsPrincipal? principal) {
        string? userId = principal?.FindFirst(CustomClaims.Sub)?.Value;

        return Guid.TryParse(userId, out Guid parsedUserId) ?
            parsedUserId :
            throw new ModubenException("User identifier is unavailable");
    }

    public static string GetIdentityId(this ClaimsPrincipal? principal) {
        return principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
               throw new ModubenException("User identity is unavailable");
    }

    public static HashSet<string> GetPermissions(this ClaimsPrincipal? principal) {
        IEnumerable<Claim> permissionClaims = principal?.FindAll(CustomClaims.Permission) ??
                                              throw new ModubenException("Permissions are unavailable");

        return permissionClaims.Select(c => c.Value).ToHashSet();
    }
}
