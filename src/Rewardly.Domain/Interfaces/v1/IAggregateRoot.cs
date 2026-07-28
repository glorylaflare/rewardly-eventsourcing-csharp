namespace Rewardly.Domain.Interfaces.v1;

/// <summary>
/// Define o contrato base de uma raiz de agregado no contexto de DDD,
/// incluindo identidade, versionamento e gestão de eventos não persistidos.
/// </summary>
public interface IAggregateRoot
{
    /// <summary>
    /// Obtém o identificador único da raiz de agregado.
    /// </summary>
    Guid Id { get; }
    /// <summary>
    /// Obtém a versão atual da raiz de agregado para controle de concorrência otimista.
    /// </summary>
    int Version { get; }

    /// <summary>
    /// Retorna a coleção imutável de eventos de domínio ainda não confirmados no repositório de eventos.
    /// </summary>
    /// <returns>Coleção somente leitura com os eventos pendentes de persistência.</returns>
    IReadOnlyCollection<IEvent> GetUncommittedEvents();
    /// <summary>
    /// Limpa os eventos não confirmados após a persistência bem-sucedida.
    /// </summary>
    void ClearUncommittedEvents();
    /// <summary>
    /// Reidrata o estado do agregado a partir de um histórico de eventos previamente persistidos.
    /// </summary>
    /// <param name="events">Sequência cronológica de eventos utilizada para recompor o estado do agregado.</param>
    void LoadFromHistory(IEnumerable<IEvent> events);
}
