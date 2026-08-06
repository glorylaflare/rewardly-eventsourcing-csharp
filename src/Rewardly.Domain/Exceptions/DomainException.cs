namespace Rewardly.Domain.Exceptions;

public class DomainException : RewardlyException
{
    public DomainException(string message) : base(
        message, 
        "", 
        RewardlyExceptionCategory.Domain) { }
}
