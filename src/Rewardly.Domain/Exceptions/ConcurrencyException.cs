namespace Rewardly.Domain.Exceptions;

public class ConcurrencyException : Exception
{
    public ConcurrencyException() { }
    public ConcurrencyException(string? message) : base(message) { }

    public ConcurrencyException(
        Guid aggregateId,
        int expectedVersion,
        int currentVersion)
    : base($"Concurrency conflict for aggregate '{aggregateId}'. Expected version {expectedVersion}, but found {currentVersion}.") { }
}
