using Clean.Application.Abstractions.Messaging;

namespace Clean.Application.Features.Todos.Update;

public sealed record UpdateTodoCommand(
    Guid TodoItemId,
    string Description) : ICommand;
