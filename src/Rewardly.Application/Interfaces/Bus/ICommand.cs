namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// Define um comando que produz uma resposta tipada após o processamento.
/// </summary>
/// <typeparam name="TResponse">Tipo de resposta retornada pelo manipulador do comando.</typeparam>
public interface ICommand<out TResponse> : ICommandBase { }

/// <summary>
/// Reúne metadados comuns aplicáveis a todos os comandos da aplicação.
/// </summary>
public interface ICommandBase { }
