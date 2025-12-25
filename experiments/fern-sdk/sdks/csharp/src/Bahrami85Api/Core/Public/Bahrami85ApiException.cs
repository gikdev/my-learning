namespace Bahrami85Api;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class Bahrami85ApiException(string message, Exception? innerException = null)
    : Exception(message, innerException);
