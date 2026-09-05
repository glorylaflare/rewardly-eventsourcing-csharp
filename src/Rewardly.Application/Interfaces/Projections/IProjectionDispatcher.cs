namespace Rewardly.Application.Interfaces.Projections;

/// <summary>
/// Define o componente responsável por despachar eventos de domínio para os manipuladores de projeção.
/// </summary>
public interface IProjectionDispatcher
{
    /// <summary>
    /// Despacha uma coleção de eventos para atualização das projeções de leitura.
    /// </summary>
    /// <param name="events">Eventos de domínio que devem ser processados pelas projeções.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão do despacho de eventos.</returns>
    Task DispatchAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken);
}
