using Rewardly.Application.Interfaces.Pipeline;

namespace Rewardly.Application.Bus;

public class CommandBus : ICommandBus
{
    private readonly IPipelineExecutor _pipeline;

    public CommandBus(IPipelineExecutor pipeline)
    {
        _pipeline = pipeline;
    }

    public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken)
    {
        return await _pipeline.ExecuteAsync(command, cancellationToken);
    }
}
