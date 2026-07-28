using Rewardly.Domain.Notifications.v1;

namespace Rewardly.Domain.Interfaces.v1;

/// <summary>
/// Define o contrato para coleta e consulta de notificações de domínio.
/// </summary>
public interface INotification
{
    /// <summary>
    /// Obtém a coleção somente leitura de notificações registradas.
    /// </summary>
    IReadOnlyCollection<Notification> Notifications { get; }
    /// <summary>
    /// Indica se há ao menos uma notificação registrada.
    /// </summary>
    bool HasNotifications { get; }

    /// <summary>
    /// Adiciona uma notificação a partir de código e mensagem descritiva.
    /// </summary>
    /// <param name="code">Código identificador da notificação.</param>
    /// <param name="message">Mensagem detalhada da notificação.</param>
    void AddNotification(string code, string message);
    /// <summary>
    /// Adiciona uma instância de notificação já construída.
    /// </summary>
    /// <param name="notification">Objeto de notificação a ser registrado.</param>
    void AddNotification(Notification notification);
    /// <summary>
    /// Adiciona um conjunto de notificações de uma única vez.
    /// </summary>
    /// <param name="notifications">Coleção de notificações a serem registradas.</param>
    void AddNotification(IEnumerable<Notification> notifications);
}
