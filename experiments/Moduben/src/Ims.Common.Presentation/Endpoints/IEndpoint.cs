using Microsoft.AspNetCore.Routing;

namespace Ims.Common.Presentation.Endpoints;

public interface IEndpoint {
    void MapEndpoint(IEndpointRouteBuilder app);
}
