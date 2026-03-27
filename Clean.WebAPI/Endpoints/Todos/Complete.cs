using Clean.Application.Abstractions.Messaging;
using Clean.Application.Features.Todos.Complete;
using Clean.SharedKernel;
using Clean.WebAPI.Extensions;
using Clean.WebAPI.Infrastructure;

namespace Clean.WebAPI.Endpoints.Todos;

public sealed class Complete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("todos/{id:guid}/complete", async (
                Guid id,
                ICommandHandler<CompleteTodoCommand> handler,
                CancellationToken cancellationToken) =>
            {
                var command = new CompleteTodoCommand(id);

                Result result = await handler.Handle(command, cancellationToken);

                return result.Match(Results.NoContent, CustomResults.Problem);
            })
            .WithTags(Tags.Todos)
            .RequireAuthorization();
    }
}