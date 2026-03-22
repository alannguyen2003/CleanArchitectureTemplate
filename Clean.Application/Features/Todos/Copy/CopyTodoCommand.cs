using Clean.Application.Abstractions.Messaging;

namespace Clean.Application.Features.Todos.Copy;

public sealed class CopyTodoCommand : ICommand<Guid>
{
    public Guid UserId { get; set; }
    public Guid TodoId { get; set; }
}