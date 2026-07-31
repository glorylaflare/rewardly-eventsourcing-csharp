namespace Rewardly.Application.Interfaces.Pipeline;

/// <summary>
/// Define um comportamento de pipeline executado em torno do manipulador de comandos.
/// </summary>
/// <typeparam name="TRequest">Tipo do comando processado no pipeline.</typeparam>
/// <typeparam name="TResponse">Tipo da resposta produzida ao final do processamento.</typeparam>
public interface IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
{
    /// <summary>
    /// Executa a lógica do comportamento e encadeia a próxima etapa do pipeline.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="next">Delegado que representa a próxima etapa do pipeline.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Resposta resultante da execução da cadeia de pipeline.</returns>
    Task<TResponse> HandleAsync(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);
}