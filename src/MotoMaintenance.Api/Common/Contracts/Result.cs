namespace MotoMaintenance.Api.Common.Contracts;

public sealed record Result<T>(T? Value, bool IsSuccess, string? Error)
{
    public static Result<T> Success(T value) => new(value, true, null);
    public static Result<T> Failure(string error) => new(default, false, error);
}