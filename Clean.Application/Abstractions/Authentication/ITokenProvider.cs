using Clean.Domain.Users;

namespace Clean.Application.Abstractions.Authentication;

public interface ITokenProvider
{
    string Create(User user);
}