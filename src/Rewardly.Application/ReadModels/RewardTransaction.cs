namespace Rewardly.Application.ReadModels;

public sealed class RewardTransaction
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public TransactionType Type { get; private set; }
    public int Points { get; private set; }
    public DateTime OccurredAt { get; private set; }

    public RewardTransaction(Guid id, Guid accountId, TransactionType type, int points, DateTime occurredAt)
    {
        Id = id;
        AccountId = accountId;
        Type = type;
        Points = points;
        OccurredAt = occurredAt;
    }
}

public enum TransactionType
{
    Credit, 
    Debit, 
    Redemption, 
    Expiration
}
