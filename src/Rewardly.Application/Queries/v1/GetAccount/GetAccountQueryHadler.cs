using Rewardly.Application.Interfaces.Bus.Query;
using Rewardly.Domain.Exceptions;

namespace Rewardly.Application.Queries.v1.GetAccount;

public sealed class GetAccountQueryHandler : IQueryHandler<GetAccountQuery, GetAccountResponse>
{
    private readonly IRewardAccountRepository _repository;

    public GetAccountQueryHandler(IRewardAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAccountResponse> HandleAsync(GetAccountQuery request, CancellationToken cancellationToken)
    {
        RewardAccount? account = await _repository.FindAsync(request.UserId, cancellationToken);

        if (account is null)
            throw new AccountNotFoundException("Account projection was not found.");

        return GetAccountMapper.ToResponse(account);
    }
}
