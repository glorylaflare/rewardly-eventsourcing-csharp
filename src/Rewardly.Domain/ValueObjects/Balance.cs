namespace Rewardly.Domain.ValueObjects;

public sealed class Balance
{
    public int Value { get; private set; }

    public Balance(int value)
    {
        if (value < 0)
            throw new DomainException("Balance cannot be negative", TransactionErrorCodes.NegativePoints);

        Value = value;
    }

    public void Add(int points)
    {
        if (points <= 0)
            throw new DomainException("Points must be greater than zero", TransactionErrorCodes.InvalidTransaction);

        Value += points;
    }

    public void Subtract(int points)
    {
        if (points <= 0)
            throw new DomainException("Points must be greater than zero", TransactionErrorCodes.InvalidTransaction);

        if (Value < points)
            throw new DomainException("Insufficient balance", TransactionErrorCodes.InsufficientPoints);

        Value -= points;
    }
}
