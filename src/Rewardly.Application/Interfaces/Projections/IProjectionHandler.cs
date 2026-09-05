namespace Rewardly.Application.Interfaces.Projections;

/// <summary>
/// Define o contrato de manipulação de um evento específico para atualização de projeções.
/// </summary>
/// <typeparam name="TEvent">Tipo do evento de domínio tratado pelo manipulador.</typeparam>
public interface IProjectionHandler<in TEvent> 
    where TEvent : IEvent
{
    /// <summary>
    /// Processa o evento informado e aplica as alterações necessárias no modelo de leitura.
    /// </summary>
    /// <param name="event">Evento de domínio a ser projetado.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão do processamento da projeção.</returns>
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken);
}
