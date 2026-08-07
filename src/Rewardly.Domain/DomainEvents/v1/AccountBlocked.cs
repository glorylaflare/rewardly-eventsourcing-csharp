namespace Rewardly.Domain.DomainEvents.v1;

public sealed class AccountBlocked : DomainEvent
{
    public string Reason { get; }

    [JsonConstructor]
    public AccountBlocked(Guid aggregateId, string reason) 
        : base(aggregateId)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new DomainException("Block reason is required", ValidationErrorCodes.InvalidRequest);

        Reason = reason;
    }
}
