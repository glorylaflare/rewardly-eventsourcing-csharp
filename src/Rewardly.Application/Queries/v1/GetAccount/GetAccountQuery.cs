using Rewardly.Application.Interfaces.Bus.Query;

namespace Rewardly.Application.Queries.v1.GetAccount;

public sealed record GetAccountQuery(Guid UserId) : IQuery<GetAccountResponse>;
