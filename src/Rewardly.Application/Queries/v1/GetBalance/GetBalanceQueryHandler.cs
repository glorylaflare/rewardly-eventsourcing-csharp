using Rewardly.Application.Interfaces.Bus.Query;
using Rewardly.Domain.Exceptions;

namespace Rewardly.Application.Queries.v1.GetBalance;

public sealed class GetBalanceQueryHandler : IQueryHandler<GetBalanceQuery, GetBalanceResponse>
{
    private readonly IRewardAccountRepository _repository;

    public GetBalanceQueryHandler(IRewardAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetBalanceResponse> HandleAsync(GetBalanceQuery request, CancellationToken cancellationToken)
    {
        RewardAccount? account = await _repository.FindAsync(request.UserId, cancellationToken);

        if (account is null)
            throw new AccountNotFoundException("Account projection was not found.");

        return GetBalanceMapper.ToResponse(account);
    }
}
