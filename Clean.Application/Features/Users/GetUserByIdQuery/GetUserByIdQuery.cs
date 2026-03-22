using Clean.Application.Abstractions.Messaging;

namespace Clean.Application.Features.Users.GetUserByIdQuery;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
