using HomeFinanceHub.WebApi.Endpoints.Person;

namespace HomeFinanceHub.WebApi.Extensions
{
    internal static class EndpointExtensions
    {
        internal static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            return endpointRouteBuilder
                .MapPersonEndpoints();
        }
    }
}
