namespace Rewardly.Application.Interfaces.Projections;

/// <summary>
/// Define o contrato para invocação dinâmica de manipuladores de projeção.
/// </summary>
public interface IProjectionInvoker
{
    /// <summary>
    /// Invoca o manipulador de projeção compatível com o evento informado.
    /// </summary>
    /// <param name="event">Evento de domínio a ser encaminhado ao manipulador de projeção.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão da invocação do manipulador.</returns>
    Task InvokeAsync(IEvent @event, CancellationToken cancellationToken);
}