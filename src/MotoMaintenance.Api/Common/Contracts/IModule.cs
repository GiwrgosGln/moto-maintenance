namespace MotoMaintenance.Api.Common.Contracts;

public interface IModule
{
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app);
}