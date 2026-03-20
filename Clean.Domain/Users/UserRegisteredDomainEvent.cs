using Clean.SharedKernel;

namespace Clean.Domain.Users;

public sealed record UserRegisteredDomainEvent(Guid UserId) : IDomainEvent;