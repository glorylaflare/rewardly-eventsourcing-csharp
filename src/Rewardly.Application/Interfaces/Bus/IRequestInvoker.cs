namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// Define o contrato para invocação dinâmica de requisições no pipeline de aplicação.
/// </summary>
public interface IRequestInvoker
{
    /// <summary>
    /// Invoca o manipulador associado à requisição informada.
    /// </summary>
    /// <param name="request">Requisição de aplicação a ser executada.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Resultado da execução da requisição em formato não tipado.</returns>
    Task<object?> InvokeAsync(IRequest request, CancellationToken cancellationToken);
}
