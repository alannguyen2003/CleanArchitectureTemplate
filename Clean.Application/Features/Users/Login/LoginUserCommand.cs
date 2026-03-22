using Clean.Application.Abstractions.Messaging;

namespace Clean.Application.Features.Users.Login;

public sealed record LoginUserCommand(string Email, string Password) : ICommand<string>;
