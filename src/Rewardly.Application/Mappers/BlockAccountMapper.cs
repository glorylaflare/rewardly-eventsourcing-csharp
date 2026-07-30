using Rewardly.Application.Commands.v1.BlockAccount;
using Rewardly.Application.Requests;

namespace Rewardly.Application.Mappers;

internal static class BlockAccountMapper
{
    public static BlockAccountRequest ToRequest(BlockAccountCommand source)
        => new BlockAccountRequest(source.AggregateId, source.Reason);
}
