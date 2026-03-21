using Clean.Domain.Todos;
using Clean.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Clean.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}