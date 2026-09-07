using Rewardly.Application.Interfaces.Bus.Query;

namespace Rewardly.Application.Queries.v1.GetBalance;

public sealed record GetBalanceQuery(Guid UserId) : IQuery<GetBalanceResponse>;