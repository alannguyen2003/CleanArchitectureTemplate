using FluentValidation;

namespace Clean.Application.Features.Todos.Complete;

public sealed class CompleteTodoCommandValidator : AbstractValidator<CompleteTodoCommand>
{
    public CompleteTodoCommandValidator()
    {
        RuleFor(c => c.TodoItemId).NotEmpty();
    }
}