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

    public RewardAccount(Guid id, Guid userId, int balance, AccountStatus status)
    {
        Id = id;
        UserId = userId;
        Balance = balance;
        Status = status;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateBalance(int points)
    {
        Balance += points;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetBlockedAccount()
    {
        Status = AccountStatus.Blocked;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetCancelledAccount()
    {
        Status = AccountStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }
}
