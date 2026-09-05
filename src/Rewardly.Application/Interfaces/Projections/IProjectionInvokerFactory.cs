namespace Rewardly.Application.Interfaces.Projections;

/// <summary>
/// Define a fábrica responsável por criar invocadores de projeção por tipo de evento.
/// </summary>
public interface IProjectionInvokerFactory
{
    /// <summary>
    /// Cria o invocador de projeção adequado para o tipo de evento informado.
    /// </summary>
    /// <param name="eventType">Tipo concreto do evento de domínio a ser processado.</param>
    /// <returns>Invocador capaz de encaminhar o evento ao manipulador correto.</returns>
    IProjectionInvoker Create(Type eventType);
}
