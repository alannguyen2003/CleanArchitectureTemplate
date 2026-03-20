using Clean.SharedKernel;

namespace Clean.Domain.Todos;

public sealed record TodoItemCompletedDomainEvent(Guid TodoItemId) : IDomainEvent
{
    
}