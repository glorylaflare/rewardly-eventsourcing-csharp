using Rewardly.Domain.Abstractions;
using Rewardly.Domain.DomainEvents.v1;
using Rewardly.Domain.Enums;
using Rewardly.Domain.Interfaces.v1;
using Rewardly.Domain.Specifications;
using Rewardly.Domain.ValueObjects;

namespace Rewardly.Domain.Aggregates;

public sealed class RewardlyAccount : AggregateRoot
{
    public Guid UserId { get; private set; }
    public Balance Balance { get; private set; } = null!;
    public AccountStatus Status { get; private set; }

    private RewardlyAccount() { }

    public static RewardlyAccount Create(Guid aggregateId, Guid userId)
    {
        RewardlyAccount? account = new RewardlyAccount();
        account.RaiseEvent(new AccountCreated(aggregateId, userId));
        return account;
    }

    public static RewardlyAccount FromHistory(IEnumerable<IEvent> events)
    {
        List<IEvent>? history = events.ToList();

        if (history.Count == 0)
        {
            throw new InvalidOperationException("History cannot be empty.");
        }

        RewardlyAccount? account = new RewardlyAccount();
        account.LoadFromHistory(events);
        return account;
    }

    public void CreditPoint(int points, string? reason)
    {
        EnsureActive();
        ValidatePoints(points);
        RaiseEvent(new PointsCredited(Id, points, reason));
    }

    public void DebitPoints(int points, string reason)
    {
        EnsureActive();
        ValidatePoints(points);
        EnsureSufficientBalance(points);
        RaiseEvent(new PointsDebited(Id, points, reason));
    }

    public void RewardRedeem(Guid rewardId, int points)
    {
        EnsureActive();
        ValidatePoints(points);
        EnsureSufficientBalance(points);
        RaiseEvent(new RewardRedeemed(Id, rewardId, points));
    }

    public void ExpirePoints(int points)
    {
        EnsureActive();
        ValidatePoints(points);

        if (Balance.Value > points)
        {
            RaiseEvent(new PointsExpired(Id, points));
        }
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

        if (Balance.Value > 0)
            throw new DomainException("You can't cancel an account with remaining points", AccountErrorCodes.AccountHasRemainingPoints);

        RaiseEvent(new AccountCancelled(Id, reason));
    }

    #region APPLY METHODS USING BY REFLECTION ON APPLYEVENT() METHOD
    private void Apply(AccountCreated @event)
    {
        Id = @event.AggregateId;
        UserId = @event.UserId;
        Balance = new Balance(0);
        Status = AccountStatus.Active;
    }

    private void Apply(PointsCredited @event)
    {
        Balance.Add(@event.Points);
    }

    private void Apply(PointsDebited @event)
    {
        Balance.Subtract(@event.Points);
    }

    private void Apply(PointsExpired @event)
    {
        Balance.Subtract(@event.Points);
    }

    private void Apply(RewardRedeemed @event)
    {
        Balance.Subtract(@event.Points);
    }

    private void Apply(AccountBlocked @event)
    {
        Status = AccountStatus.Blocked;
    }

    private void Apply(AccountCancelled @event)
    {
        Status = AccountStatus.Cancelled;
    }
    #endregion

    private void EnsureActive()
    {
        if (!new AccountMustBeActive().IsSatisfiedBy(this))
            throw new DomainException("Account is not active", AccountErrorCodes.AccountInactive);
    }

    private void ValidatePoints(int points)
    {
        if (points <= 0)
            throw new DomainException("Invalid points", TransactionErrorCodes.InvalidPoints);
    }

    private void EnsureSufficientBalance(int points)
    {
        if (!new HasSufficientBalance(points).IsSatisfiedBy(this))
            throw new DomainException("Insufficient balance", TransactionErrorCodes.InsufficientPoints);
    }
}
