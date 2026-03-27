using Clean.Application.Abstractions.Messaging;
using Clean.Application.Features.Todos.Get;
using Clean.SharedKernel;
using Clean.WebAPI.Extensions;
using Clean.WebAPI.Infrastructure;

namespace Clean.WebAPI.Endpoints.Todos;

public sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("todos", async (
                Guid userId,
                IQueryHandler<GetTodosQuery, List<TodoResponse>> handler,
                CancellationToken cancellationToken) =>
            {
                var query = new GetTodosQuery(userId);

                Result<List<TodoResponse>> result = await handler.Handle(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Todos)
            .RequireAuthorization();
    }
}