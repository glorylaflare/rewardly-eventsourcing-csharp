namespace Rewardly.Application.Bus;

public sealed class RequestInvoker<TRequest, TResponse> : IRequestInvoker
    where TRequest : IRequest<TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> _handler;

    public RequestInvoker(IRequestHandler<TRequest, TResponse> handler)
    {
        _handler = handler;
    }

    public async Task<object?> InvokeAsync(IRequest request, CancellationToken cancellationToken)
    {
        return await _handler.HandleAsync((TRequest)request, cancellationToken);
    }
}
