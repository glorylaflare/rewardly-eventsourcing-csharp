namespace Rewardly.Domain.Exceptions;

public class AggregateNotFoundException : Exception
{
    public AggregateNotFoundException() { }
    public AggregateNotFoundException(string? message) : base(message) { }
}
