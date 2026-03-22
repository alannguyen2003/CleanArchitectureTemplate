using Clean.Application.Abstractions.Data;
using Clean.Application.Abstractions.Messaging;
using Clean.Domain.Todos;
using Clean.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Features.Todos.Update;

public sealed class UpdateTodoCommandHandler(
    IApplicationDbContext context)
    : ICommandHandler<UpdateTodoCommand>
{
    public async Task<Result> Handle(UpdateTodoCommand command, CancellationToken cancellationToken)
    {
        TodoItem? todoItem = await context.TodoItems
            .SingleOrDefaultAsync(t => t.Id == command.TodoItemId, cancellationToken);

        if (todoItem is null)
        {
            return Result.Failure(TodoItemErrors.NotFound(command.TodoItemId));
        }

        todoItem.Description = command.Description;

        await context.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}