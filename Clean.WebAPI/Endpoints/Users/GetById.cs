using System.Security.Claims;
using Clean.Application.Abstractions.Authentication;
using Clean.Application.Abstractions.Messaging;
using Clean.Application.Features.Users.GetUserByIdQuery;
using Clean.SharedKernel;
using Clean.WebAPI.Extensions;
using Clean.WebAPI.Infrastructure;

namespace Clean.WebAPI.Endpoints.Users;

public sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{userId}", async (
                Guid userId,
                IQueryHandler<GetUserByIdQuery, UserResponse> handler,
                IHttpContextAccessor httpContextAccessor,
                CancellationToken cancellationToken) =>
            {
                var query = new GetUserByIdQuery(userId);

                Result<UserResponse> result = await handler.Handle(query, cancellationToken);
                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .HasPermission(Permissions.UsersAccess)
            .WithTags(Tags.Users);
    }
}