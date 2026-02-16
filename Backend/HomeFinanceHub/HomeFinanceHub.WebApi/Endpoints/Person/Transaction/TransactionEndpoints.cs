using HomeFinanceHub.Domain.DTOs.Person.Transaction.Request;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Transaction.Commands;
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
                .WithDescription("Endpoint responsável por criar uma transação vinculada a uma pessoa.");

            return endpointRouteBuilder;
        }
    }
}
