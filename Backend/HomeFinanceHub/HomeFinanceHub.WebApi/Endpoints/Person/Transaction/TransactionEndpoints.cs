using HomeFinanceHub.Domain.DTOs.Common;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Request;
using HomeFinanceHub.Domain.DTOs.Person.Transaction.Response;
using HomeFinanceHub.Domain.Errors;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Commands;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinanceHub.WebApi.Endpoints.Person.Transaction
{
    internal static class TransactionEndpoints
    {
        internal static IEndpointRouteBuilder MapTransactionEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var root = endpointRouteBuilder.MapGroup("person/transaction")
                .WithTags("Transaction")
                .WithOpenApi();

            root.MapPost("", async (
                [FromServices] ICreateTransactionService service,
                [FromBody] RequestCreateTransactionDTO content,
                CancellationToken cancellationToken = default
            ) =>
            {
                var result = await service.CreateAsync(content, cancellationToken);

                return result.Match(
                    success => Results.Created(string.Empty, success),
                    error => Results.Json(error, statusCode: error.HttpErrorCode)
                );
            })
                .WithDescription("Endpoint responsável por criar uma transação vinculada a uma pessoa.")
                .Produces<bool>(StatusCodes.Status201Created)
                .Produces<BaseError>(StatusCodes.Status404NotFound)
                .Produces<BaseError>(StatusCodes.Status409Conflict)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            root.MapGet("", async (
                [FromServices] IGetTransactionPaginatedService service,
                [FromQuery] int page = 0,
                [FromQuery] sbyte pageSize = 10,
                CancellationToken cancellationToken = default
            ) =>
            {
                return await service.GetPaginatedAsync(page, pageSize, cancellationToken);
            })
                .WithDescription("Endpoint responsável por retornar as transações existentes.")
                .Produces<PaginatedDTO<ResponseTransactionItemDTO>>(StatusCodes.Status200OK)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            return endpointRouteBuilder;
        }
    }
}
