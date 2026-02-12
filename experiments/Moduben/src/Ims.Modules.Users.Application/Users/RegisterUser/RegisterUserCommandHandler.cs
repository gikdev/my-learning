using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Users.Application.Abstractions.Data;
using Ims.Modules.Users.Application.Abstractions.Identity;
using Ims.Modules.Users.Domain.Users;

namespace Ims.Modules.Users.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler(
    IIdentityProviderService identityProviderService,
    IUserRepository          userRepository,
    IUnitOfWork              unitOfWork)
    : ICommandHandler<RegisterUserCommand, Guid> {
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken) {
        Result<string> result = await identityProviderService.RegisterUserAsync(
            new UserModel(request.Email, request.Password, request.FirstName, request.LastName),
            cancellationToken);

        if (result.IsFailure) {
            return Result.Failure<Guid>(result.Error);
        }

        var user = User.Create(request.Email, request.FirstName, request.LastName, result.Value);

        userRepository.Insert(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
