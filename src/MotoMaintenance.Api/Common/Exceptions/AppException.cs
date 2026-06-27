namespace MotoMaintenance.Api.Common.Exceptions;

public abstract class AppException(string message, int statusCode) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
    public virtual string Title => "An error occurred";
}