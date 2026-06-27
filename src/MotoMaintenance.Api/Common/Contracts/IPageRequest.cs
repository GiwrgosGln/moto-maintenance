namespace MotoMaintenance.Api.Common.Contracts;

public interface IPageRequest
{
    int Page { get; }
    int PageSize { get; }
    string? SortBy { get; }
    bool Descending { get; }
}