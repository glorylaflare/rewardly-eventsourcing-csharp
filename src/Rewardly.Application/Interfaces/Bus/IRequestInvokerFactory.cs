namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// Define a fábrica responsável por resolver o invocador adequado para cada requisição.
/// </summary>
public interface IRequestInvokerFactory
{
    /// <summary>
    /// Cria o invocador compatível com o tipo concreto da requisição informada.
    /// </summary>
    /// <param name="request">Requisição para a qual o invocador será resolvido.</param>
    /// <returns>Invocador capaz de executar o manipulador da requisição.</returns>
    IRequestInvoker Create(IRequest request);
}
