using Ims.Common.Application.Exceptions;
using Ims.Common.Infrastructure.Authentication;
using Ims.Modules.Ticketing.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

namespace Ims.Modules.Ticketing.Infrastructure.Authentication;

internal sealed class CustomerContext(IHttpContextAccessor httpContextAccessor) : ICustomerContext {
    public Guid CustomerId => httpContextAccessor.HttpContext?.User.GetUserId() ??
                              throw new ImsException("User identifier is unavailable");
}
