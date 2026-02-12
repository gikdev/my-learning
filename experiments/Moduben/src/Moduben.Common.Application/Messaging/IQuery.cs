using Moduben.Common.Domain;
using MediatR;

namespace Moduben.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
