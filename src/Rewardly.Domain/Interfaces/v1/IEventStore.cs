namespace Rewardly.Domain.Interfaces.v1;

/// <summary>
/// Define operações de persistência e recuperação de eventos em um armazenamento de eventos.
/// </summary>
public interface IEventStore
{
    /// <summary>
    /// Persiste os eventos não confirmados de um agregado, aplicando verificação de versão esperada.
    /// </summary>
    /// <param name="aggregateId">Identificador do agregado cujos eventos serão persistidos.</param>
    /// <param name="expectedVerion">Versão esperada do agregado para validação de concorrência.</param>
    /// <param name="uncommittedEvents">Eventos pendentes de persistência.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa assíncrona que representa a conclusão da persistência.</returns>
    Task SaveAsync(
        Guid aggregateId,
        int expectedVerion,
        IEnumerable<IEvent> uncommittedEvents,
        CancellationToken cancellationToken);
    
    /// <summary>
    /// Recupera o histórico completo de eventos associado a um agregado.
    /// </summary>
    /// <param name="aggregateId">Identificador do agregado a ser reconstituído.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Coleção somente leitura com os eventos do agregado, em ordem de persistência.</returns>
    Task<IReadOnlyCollection<IEvent>> LoadAsync(
        Guid aggregateId, 
        CancellationToken cancellationToken);
}
