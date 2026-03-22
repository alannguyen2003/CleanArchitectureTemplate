using Clean.Application.Abstractions.Messaging;

namespace Clean.Application.Features.Todos.Delete;

public sealed record DeleteTodoCommand(Guid TodoItemId) : ICommand;
