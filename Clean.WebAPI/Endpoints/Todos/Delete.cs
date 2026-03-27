using Clean.Application.Abstractions.Messaging;
using Clean.Application.Features.Todos.Delete;
using Clean.SharedKernel;
using Clean.WebAPI.Extensions;
using Clean.WebAPI.Infrastructure;

namespace Clean.WebAPI.Endpoints.Todos;

public sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("todos/{id:guid}", async (
                Guid id,
                ICommandHandler<DeleteTodoCommand> handler,
                CancellationToken cancellationToken) =>
            {
                var command = new DeleteTodoCommand(id);

                Result result = await handler.Handle(command, cancellationToken);

                return result.Match(Results.NoContent, CustomResults.Problem);
            })
            .WithTags(Tags.Todos)
            .RequireAuthorization();
    }
}