namespace Rewardly.Domain.Errors;

public static class AccountErrorCodes
{
    public const string AccountNotFound = "ACCOUNT_NOT_FOUND";
    public const string AccountAlreadyExists = "ACCOUNT_ALREADY_EXISTS";
    public const string AccountBlocked = "ACCOUNT_BLOCKED";
    public const string AccountCancelled = "ACCOUNT_CANCELLED";
    public const string AccountInactive = "ACCOUNT_INACTIVE";
    public const string AccountHasRemainingPoints = "ACCOUNT_HAS_REMAINING_POINTS";
}
