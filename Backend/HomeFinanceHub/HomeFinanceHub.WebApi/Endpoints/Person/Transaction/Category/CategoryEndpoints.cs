using HomeFinanceHub.Domain.DTOs.Common;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Request;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Category.Response;
using HomeFinanceHub.Domain.Errors;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Commands;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Category.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinanceHub.WebApi.Endpoints.Person.Transaction.Category
{
    internal static class CategoryEndpoints
    {
        internal static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var root = endpointRouteBuilder.MapGroup("person/transaction/category")
                .WithTags("Category")
                .WithOpenApi();

            root.MapGet("", async (
                [FromServices] IGetPaginatedCategoryService service,
                [FromQuery] int page = 0,
                [FromQuery] sbyte pageSize = 10,
                CancellationToken cancellationToken = default
            ) =>
            {
                return await service.GetPaginatedAsync(page, pageSize, cancellationToken);
            })
                .WithDescription("Endpoint responsável por retornar a listagem paginada de categorias.")
                .Produces<PaginatedDTO<ResponsePaginatedCategoryDTO>>(StatusCodes.Status200OK)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            root.MapPost("", async (
                [FromServices] ICreateCategoryService service,
                [FromBody] RequestCreateCategoryDTO content,
                CancellationToken cancellationToken = default
            ) =>
            {
                var result = await service.CreateAsync(content, cancellationToken);

                return result.Match(
                    success => Results.Created(string.Empty, success),
                    error => Results.Json(error, statusCode: error.HttpErrorCode)
                );
            })
                .WithDescription("Endpoint responsável por criar uma categoria.")
                .Produces<bool>(StatusCodes.Status201Created)
                .Produces<BaseError>(StatusCodes.Status400BadRequest)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            root.MapGet("search", async (
                [FromServices] ISearchCategoryService service,
                [FromQuery] string? name,
                CancellationToken cancellationToken = default
            ) =>
            {
                return await service.SearchAsync(name, cancellationToken);
            })
                .WithDescription("Endpoint responsável por retornar a listagem de categorias filtradas pelo nome")
                .Produces<IEnumerable<KeyValuePair<long, string>>>(StatusCodes.Status200OK)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            return endpointRouteBuilder;
        }
    }
}
