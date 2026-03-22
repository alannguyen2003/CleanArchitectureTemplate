using Clean.Application.Abstractions.Authentication;
using Clean.Application.Abstractions.Data;
using Clean.Application.Abstractions.Messaging;
using Clean.Domain.Todos;
using Clean.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Features.Todos.GetById;

public sealed class GetTodoByIdQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetTodoByIdQuery, TodoResponse>
{
    public async Task<Result<TodoResponse>> Handle(GetTodoByIdQuery query, CancellationToken cancellationToken)
    {
        TodoResponse? todo = await context.TodoItems
            .Where(todoItem => todoItem.Id == query.TodoItemId && todoItem.UserId == userContext.UserId)
            .Select(todoItem => new TodoResponse
            {
                Id = todoItem.Id,
                UserId = todoItem.UserId,
                Description = todoItem.Description,
                DueDate = todoItem.DueDate,
                Labels = todoItem.Labels,
                IsCompleted = todoItem.IsCompleted,
                CreatedAt = todoItem.CreatedAt,
                CompletedAt = todoItem.CompletedAt
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (todo is null)
        {
            return Result.Failure<TodoResponse>(TodoItemErrors.NotFound(query.TodoItemId));
        }

        return todo;
    }
}