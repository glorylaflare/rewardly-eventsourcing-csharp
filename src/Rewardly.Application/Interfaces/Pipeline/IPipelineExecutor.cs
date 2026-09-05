namespace Rewardly.Application.Interfaces.Pipeline;

/// <summary>
/// Define o executor responsável por orquestrar o pipeline de comportamentos e o manipulador final da requisição.
/// </summary>
public interface IPipelineExecutor
{
    /// <summary>
    /// Executa uma requisição tipada através da cadeia de pipeline e retorna a resposta processada.
    /// </summary>
    /// <typeparam name="TResponse">Tipo da resposta esperada ao final da execução da requisição.</typeparam>
    /// <param name="request">Requisição a ser processada no pipeline de aplicação.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Resposta resultante do processamento completo do pipeline.</returns>
    Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
}
