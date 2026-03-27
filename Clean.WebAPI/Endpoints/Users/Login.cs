using Clean.Application.Abstractions.Messaging;
using Clean.Application.Features.Users.Login;
using Clean.SharedKernel;
using Clean.WebAPI.Extensions;
using Clean.WebAPI.Infrastructure;

namespace Clean.WebAPI.Endpoints.Users;

public sealed class Login : IEndpoint
{
    public sealed record Request(string Email, string Password);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/login", async (
                Request request,
                ICommandHandler<LoginUserCommand, string> handler,
                CancellationToken cancellationToken) =>
            {
                var command = new LoginUserCommand(request.Email, request.Password);

                Result<string> result = await handler.Handle(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Users);
    }
}