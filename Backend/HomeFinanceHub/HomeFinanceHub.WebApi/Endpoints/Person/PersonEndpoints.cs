using HomeFinanceHub.Domain.DTOs.Person.Request;
using HomeFinanceHub.Domain.DTOs.Person.Response;
using HomeFinanceHub.Domain.Errors;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Commands;
using HomeFinanceHub.Domain.Interfaces.Services.Person.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinanceHub.WebApi.Endpoints.Person
{
    internal static class PersonEndpoints
    {
        internal static IEndpointRouteBuilder MapPersonEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var root = endpointRouteBuilder.MapGroup("person")
                .WithTags("Person")
                .WithOpenApi();

            root.MapPost("", async (
                [FromServices] ICreatePersonService service,
                [FromBody] CreatePersonDTO content,
                CancellationToken cancellationToken = default
            ) =>
            {
                var result = await service.CreateAsync(content, cancellationToken);

                return result.Match(
                    success => Results.Created(string.Empty, success),
                    error => Results.Json(error, statusCode: error.HttpErrorCode)
                );
            })
                .WithDescription("Endpoint responsável por criar uma pessoa.")
                .Produces<bool>(StatusCodes.Status201Created)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            root.MapPatch("", async (
                [FromServices] IUpdatePersonService service,
                [FromBody] UpdatePersonDTO content,
                CancellationToken cancellationToken = default
            ) =>
            {
                var result = await service.UpdateAsync(content, cancellationToken);

                return result.Match(
                    success => Results.Ok(success),
                    error => Results.Json(error, statusCode: error.HttpErrorCode)
                );
            })
                .WithDescription("Endpoint responsável por atualizar as informações de uma pessoa.")
                .Produces<bool>(StatusCodes.Status200OK)
                .Produces<BaseError>(StatusCodes.Status404NotFound)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            root.MapDelete("{id:long}", async (
                [FromServices] IDeletePersonService service,
                [FromRoute] long id,
                CancellationToken cancellationToken = default
            ) =>
            {
                var result = await service.DeleteAsync(id, cancellationToken);

                return result.Match(
                    _ => Results.NoContent(),
                    error => Results.Json(error, statusCode: error.HttpErrorCode)
                );
            })
                .WithDescription("Endpoint responsável por excluir uma pessoa.")
                .Produces<bool>(StatusCodes.Status200OK)
                .Produces<BaseError>(StatusCodes.Status404NotFound)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            root.MapGet("", async (
                [FromServices] IGetPaginatedPersonService service,
                [FromQuery] int page = 0,
                [FromQuery] sbyte pageSize = 10,
                CancellationToken cancellationToken = default
            ) =>
            {
                return await service.GetPaginatedAsync(page, pageSize, cancellationToken);
            })
                .WithDescription("Endpoint responsável por listar de forma paginada as pessoas do sistema")
                .Produces<PaginatedPersonDTO>(StatusCodes.Status200OK)
                .Produces<BaseError>(StatusCodes.Status500InternalServerError);

            return endpointRouteBuilder;
        }
    }
}
