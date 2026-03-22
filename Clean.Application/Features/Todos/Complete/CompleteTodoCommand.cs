using Clean.Application.Abstractions.Messaging;

namespace Clean.Application.Features.Todos.Complete;

public sealed record CompleteTodoCommand(Guid TodoItemId) : ICommand;
