namespace Rewardly.Application.Interfaces.Bus.Command;

/// <summary>
/// Define o contrato de manipulação para comandos de aplicação.
/// </summary>
/// <typeparam name="TCommand">Tipo de comando processado pelo manipulador.</typeparam>
/// <typeparam name="TResponse">Tipo de resposta retornada após a execução do comando.</typeparam>
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> 
    where TCommand : ICommand<TResponse> { }