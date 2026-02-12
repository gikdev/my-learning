using Ims.Common.Application.Messaging;
using Ims.Common.Domain;
using Ims.Modules.Ticketing.Application.Abstractions.Data;
using Ims.Modules.Ticketing.Domain.Customers;

namespace Ims.Modules.Ticketing.Application.Customers.CreateCustomer;

internal sealed class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCustomerCommand> {
    public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken) {
        var customer = Customer.Create(request.CustomerId, request.Email, request.FirstName, request.LastName);

        customerRepository.Insert(customer);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
