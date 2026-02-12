using Moduben.Common.Domain;

namespace Moduben.Common.Application.Exceptions;

public sealed class ModubenException : Exception {
    public ModubenException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException) {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
