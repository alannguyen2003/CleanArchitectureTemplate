using Clean.SharedKernel;

namespace Clean.Domain.Todos;

public class TodoItemCreatedDomainEvent(Guid TodoItemId) : IDomainEvent;