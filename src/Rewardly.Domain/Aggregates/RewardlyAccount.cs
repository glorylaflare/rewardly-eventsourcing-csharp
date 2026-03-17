using Rewardly.Domain.Abstractions;
using Rewardly.Domain.DomainEvents.v1;
using Rewardly.Domain.Enums;
using Rewardly.Domain.Exceptions;

namespace Rewardly.Domain.Aggregates;

public sealed class RewardlyAccount : AggregateRoot
{
    public Guid UserId { get; private set; }
    public int Balance { get; private set; }
    public AccountStatus Status { get; private set; }

    private RewardlyAccount() { }

    public static RewardlyAccount Create(Guid accountId, Guid userId)
    {
        var account = new RewardlyAccount();
        account.RaiseEvent(new AccountCreated(accountId, userId));
        return account;
    }

    public void CreditPoint(int points, string? reason)
    {
        if (Status != AccountStatus.Active)
            throw new DomainException("Account is not active");

        if (points <= 0)
            throw new DomainException("Points must be greater than zero");

        RaiseEvent(new PointsCredited(Id, points, reason));
    }

    public void DebitPoints(int points, string reason)
    {
        if (Status != AccountStatus.Active)
            throw new DomainException("Account is not active");

        if (points <= 0)
            throw new DomainException("Invalid points");

        if (Balance < points)
            throw new DomainException("Insufficient balance");

        RaiseEvent(new PointsDebited(Id, points, reason));
    }

    public void RewardRedeem(Guid rewardId, int points)
    {
        //TODO: Validar rewardId

        if (points <= 0)
            throw new DomainException("Invalid points");

        if (Balance < points)
            throw new DomainException("Insufficient balance");

        RaiseEvent(new RewardRedeemed(Id, rewardId, points));
    }

    public void ExpirePoints(int points)
    {
        if (points <= 0)
            throw new DomainException("Invalid points");

        RaiseEvent(new PointsExpired(Id, points));
    }

    public void Block(string reason)
    {
        if (Status == AccountStatus.Blocked)
            return;

        RaiseEvent(new AccountBlocked(Id, reason));
    }

    public void Cancel(string? reason)
    {
        if (Status == AccountStatus.Cancelled)
            return;

        if (Balance > 0)
            throw new DomainException("You can't cancel a account with remain points");

        RaiseEvent(new AccountCancelled(Id, reason));
    }

    private void Apply(AccountCreated @event)
    {
        Id = @event.AggregateId;
        UserId = @event.UserId;
        Balance = 0;
        Status = AccountStatus.Active;
    }

    private void Apply(PointsCredited @event)
    {
        Balance += @event.Points;
    }

    private void Apply(PointsDebited @event)
    {
        Balance -= @event.Points;
    }

    private void Apply(PointsExpired @event)
    {
        Balance -= @event.Points;
    }

    private void Apply(RewardRedeemed @event)
    {
        Balance -= @event.Points;
    }

    private void Apply(AccountBlocked @event)
    {
        Status = AccountStatus.Blocked;
    }

    private void Apply(AccountCancelled @event)
    {
        Status = AccountStatus.Cancelled;
    }
}
