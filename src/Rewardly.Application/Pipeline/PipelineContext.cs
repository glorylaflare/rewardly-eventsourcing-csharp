namespace Rewardly.Application.Pipeline;

public sealed class PipelineContext<TRequest>
{
    public TRequest Request { get; }

    public PipelineContext(TRequest request)
    {
        Request = request;
    }
}
