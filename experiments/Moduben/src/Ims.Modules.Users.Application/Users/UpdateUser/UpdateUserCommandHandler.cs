using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Users.Application.Abstractions.Data;
using Ims.Modules.Users.Domain.Users;

namespace Ims.Modules.Users.Application.Users.UpdateUser;

internal sealed class UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateUserCommand> {
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
        User? user = await userRepository.GetAsync(request.UserId, cancellationToken);

        if (user is null) {
            return Result.Failure(UserErrors.NotFound(request.UserId));
        }

        user.Update(request.FirstName, request.LastName);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
