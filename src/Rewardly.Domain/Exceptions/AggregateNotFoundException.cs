namespace Rewardly.Domain.Exceptions;

public class AggregateNotFoundException : RewardlyException
{
    public AggregateNotFoundException() : base(
        "Aggregate not found.",
        AggregateErrorCodes.AggregateNotFound,
        RewardlyExceptionCategory.Domain) { }

    public AggregateNotFoundException(Guid aggregateId) : base(
        $"Aggregate '{aggregateId}' was not found.",
        AggregateErrorCodes.AggregateNotFound,
        RewardlyExceptionCategory.Domain) { }

    public AggregateNotFoundException(string message) : base(
        message,
        AggregateErrorCodes.AggregateNotFound,
        RewardlyExceptionCategory.Domain) { }
}
