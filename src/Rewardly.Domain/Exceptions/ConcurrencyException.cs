namespace Rewardly.Domain.Exceptions;

public class ConcurrencyException : RewardlyException
{
    public ConcurrencyException(string message) : base(
        message,
        AggregateErrorCodes.AggregateVersionConflict,
        RewardlyExceptionCategory.Infrastructure) { }

    public ConcurrencyException(Guid aggregateId, int expectedVersion, int currentVersion) : base(
        $"Concurrency conflict for aggregate '{aggregateId}'. Expected version {expectedVersion}, but found {currentVersion}.",
        AggregateErrorCodes.AggregateVersionConflict, 
        RewardlyExceptionCategory.Infrastructure) { }
}
