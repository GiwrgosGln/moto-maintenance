namespace MotoMaintenance.Api.Common.Exceptions;

public sealed class UnauthorizedException(string message = "Access denied.")
    : AppException(message, StatusCodes.Status403Forbidden)
{
    public override string Title => "Forbidden";
}