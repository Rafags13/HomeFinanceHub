using HomeFinanceHub.WebApi.Endpoints.Person;
using HomeFinanceHub.WebApi.Endpoints.Person.Transaction.Category;

namespace HomeFinanceHub.WebApi.Extensions
{
    internal static class EndpointExtensions
    {
        internal static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            return endpointRouteBuilder
                .MapPersonEndpoints()
                .MapCategoryEndpoints();
        }
    }
}
