using Rewardly.Application.Commands.v1.CancelAccount;

namespace Rewardly.Application.Mappers;

internal static class CancelAccountMapper
{
    public static CancelAccountRequest ToRequest(CancelAccountCommand source)
        => new CancelAccountRequest(source.AggregateId, source.Reason);
}
