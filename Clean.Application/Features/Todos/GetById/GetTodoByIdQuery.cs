using Clean.Application.Abstractions.Messaging;

namespace Clean.Application.Features.Todos.GetById;

public sealed record GetTodoByIdQuery(Guid TodoItemId) : IQuery<TodoResponse>;
