using Rewardly.Domain.Enums;

namespace Rewardly.Application.ReadModels;

public sealed class RewardAccount
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public int Balance { get; private set; }
    public AccountStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public RewardAccount(Guid id, Guid userId, int balance, AccountStatus status, DateTime occurredAt)
    {
        Id = id;
        UserId = userId;
        Balance = balance;
        Status = status;
        CreatedAt = occurredAt;
        UpdatedAt = occurredAt;
    }

    public RewardAccount(Guid id, Guid userId, int balance, AccountStatus status, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        UserId = userId;
        Balance = balance;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public void UpdateBalance(int points, DateTime occurredAt)
    {
        Balance += points;
        UpdatedAt = occurredAt;
    }

    public void SetBlockedAccount(DateTime occurredAt)
    {
        Status = AccountStatus.Blocked;
        UpdatedAt = occurredAt;
    }

    public void SetCancelledAccount(DateTime occurredAt)
    {
        Status = AccountStatus.Cancelled;
        UpdatedAt = occurredAt;
    }
}
