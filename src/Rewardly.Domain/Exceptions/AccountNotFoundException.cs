namespace Rewardly.Domain.Exceptions;

public class AccountNotFoundException : RewardlyException
{
    public AccountNotFoundException() : base(
        "Account not found.",
        AccountErrorCodes.AccountNotFound,
        RewardlyExceptionCategory.Application) { }

    public AccountNotFoundException(string message) : base(
        message,
        AccountErrorCodes.AccountNotFound,
        RewardlyExceptionCategory.Application) { }
}
