using Clean.Application.Abstractions.Messaging;

namespace Clean.Application.Features.Todos.Get;

public sealed record GetTodosQuery(Guid UserId) : IQuery<List<TodoResponse>>;
