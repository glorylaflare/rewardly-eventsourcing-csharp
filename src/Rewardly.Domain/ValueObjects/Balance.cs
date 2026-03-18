using Rewardly.Domain.Exceptions;

namespace Rewardly.Domain.ValueObjects;

public sealed class Balance
{
    public int Value { get; private set; }

    public Balance(int value)
    {
        if (value < 0)
            throw new DomainException("Balance cannot be negative");

        Value = value;
    }

    public void Add(int points)
    {
        Value += points;
    }

    public void Subtract(int points)
    {
        if (Value < points)
            throw new DomainException("Insufficient balance");

        Value -= points;
    }
}
