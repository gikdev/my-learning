using Ims.Common.Domain;
using MediatR;

namespace Ims.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
