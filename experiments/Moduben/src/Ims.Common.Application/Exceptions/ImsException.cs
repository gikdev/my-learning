using Ims.Common.Domain;

namespace Ims.Common.Application.Exceptions;

public sealed class ImsException : Exception {
    public ImsException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException) {
        RequestName = requestName;
        Error       = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
