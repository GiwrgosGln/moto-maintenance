namespace MotoMaintenance.Api.Common.Exceptions;

public sealed class NotFoundException(string resource, object id)
    : AppException($"{resource} '{id}' was not found.", StatusCodes.Status404NotFound)
{
    public override string Title => "Resource not found";
}