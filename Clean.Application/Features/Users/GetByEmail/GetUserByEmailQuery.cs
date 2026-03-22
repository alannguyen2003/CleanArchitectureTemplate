using Clean.Application.Abstractions.Messaging;

namespace Clean.Application.Features.Users.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IQuery<UserResponse>;
