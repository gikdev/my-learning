using Ims.Common.Domain;

namespace Ims.Modules.Users.Application.Abstractions.Identity;

public interface IIdentityProviderService {
    Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
}
