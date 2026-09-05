namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// Define o contrato de manipulação para uma requisição de aplicação.
/// </summary>
/// <typeparam name="TRequest">Tipo de requisição processada pelo manipulador.</typeparam>
/// <typeparam name="TResponse">Tipo de resposta retornada após o processamento.</typeparam>
public interface IRequestHandler<in TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Processa a requisição informada e retorna a resposta correspondente.
    /// </summary>
    /// <param name="request">Requisição a ser processada.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Resposta resultante do processamento da requisição.</returns>
    Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
}
