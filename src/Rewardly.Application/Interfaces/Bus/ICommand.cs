namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// Define um comando que produz uma resposta tipada após o processamento.
/// </summary>
/// <typeparam name="TResponse">Tipo de resposta retornada pelo manipulador do comando.</typeparam>
public interface ICommand<out TResponse> : ICommandBase { }

/// <summary>
/// Define um comando que não produz valor de retorno explícito.
/// </summary>
public interface ICommand : ICommandBase { }

/// <summary>
/// Reúne metadados comuns aplicáveis a todos os comandos da aplicação.
/// </summary>
public interface ICommandBase
{
    /// <summary>
    /// Obtém o identificador de correlação para rastreamento ponta a ponta da requisição.
    /// </summary>
    Guid CorrelationId { get; }
    /// <summary>
    /// Obtém a data e hora de criação do comando.
    /// </summary>
    DateTime CreatedAt { get; }
}