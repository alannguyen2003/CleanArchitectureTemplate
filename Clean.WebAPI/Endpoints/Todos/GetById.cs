using Clean.Application.Abstractions.Messaging;
using Clean.Application.Features.Todos.GetById;
using Clean.SharedKernel;
using Clean.WebAPI.Extensions;
using Clean.WebAPI.Infrastructure;

namespace Clean.WebAPI.Endpoints.Todos;

public sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("todos/{id:guid}", async (
                Guid id,
                IQueryHandler<GetTodoByIdQuery, TodoResponse> handler,
                CancellationToken cancellationToken) =>
            {
                var command = new GetTodoByIdQuery(id);

                Result<TodoResponse> result = await handler.Handle(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Todos)
            .RequireAuthorization();
    }
}