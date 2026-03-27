using Clean.Application.Abstractions.Messaging;
using Clean.Application.Features.Todos.Copy;
using Clean.SharedKernel;
using Clean.WebAPI.Extensions;
using Clean.WebAPI.Infrastructure;

namespace Clean.WebAPI.Endpoints.Todos;

public sealed class Copy : IEndpoint
{
    public sealed class Request
    {
        public Guid UserId { get; set; }
        public Guid TodoId { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("todos/{todoId}/copy", async (
                Guid todoId,
                Request request,
                ICommandHandler<CopyTodoCommand, Guid> handler,
                CancellationToken cancellationToken) =>
            {
                var command = new CopyTodoCommand
                {
                    UserId = request.UserId,
                    TodoId = todoId
                };

                Result<Guid> result = await handler.Handle(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Todos)
            .RequireAuthorization();
    }
}