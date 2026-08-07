namespace Rewardly.Domain.Errors;

public static class TransactionErrorCodes
{
    public const string InsufficientPoints = "INSUFFICIENT_POINTS";
    public const string NegativePoints = "NEGATIVE_POINTS";
    public const string InvalidTransaction = "INVALID_TRANSACTION";
    public const string PointsExpired = "POINTS_EXPIRED";
    public const string InvalidPoints = "INVALID_POINTS";
}
