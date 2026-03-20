namespace Clean.SharedKernel;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}