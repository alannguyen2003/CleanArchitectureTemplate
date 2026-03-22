using Clean.Application.Abstractions.Authentication;
using Clean.Application.Abstractions.Data;
using Clean.Application.Abstractions.Messaging;
using Clean.Domain.Todos;
using Clean.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Features.Todos.Delete;

public sealed class DeleteTodoCommandHandler(IApplicationDbContext context, IUserContext userContext)
    : ICommandHandler<DeleteTodoCommand>
{
    public async Task<Result> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
    {
        TodoItem? todoItem = await context.TodoItems
            .SingleOrDefaultAsync(t => t.Id == command.TodoItemId && t.UserId == userContext.UserId, cancellationToken);

        if (todoItem is null)
        {
            return Result.Failure(TodoItemErrors.NotFound(command.TodoItemId));
        }

        context.TodoItems.Remove(todoItem);

        todoItem.Raise(new TodoItemDeletedDomainEvent(todoItem.Id));

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}