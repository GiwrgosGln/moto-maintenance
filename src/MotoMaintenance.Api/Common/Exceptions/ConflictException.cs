namespace MotoMaintenance.Api.Common.Exceptions;

public sealed class ConflictException(string message)
    : AppException(message, StatusCodes.Status409Conflict)
{
    public override string Title => "Conflict";
}