namespace Rewardly.Application.Interfaces.Pipeline;

/// <summary>
/// Representa o próximo manipulador na cadeia de execução do pipeline.
/// </summary>
/// <typeparam name="TResponse">Tipo da resposta produzida pelo manipulador.</typeparam>
/// <returns>Tarefa assíncrona que retorna a resposta do próximo passo do pipeline.</returns>
public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();

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
    /// <param name="request">Comando recebido para processamento na etapa atual do pipeline.</param>
    /// <param name="next">Delegado que representa a próxima etapa do pipeline.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Resposta resultante da execução da cadeia de pipeline.</returns>
    Task<TResponse> HandleAsync(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);
}