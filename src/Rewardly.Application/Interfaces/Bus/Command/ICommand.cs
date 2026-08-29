namespace Rewardly.Application.Interfaces.Bus.Command;

/// <summary>
/// Representa um comando de aplicação que altera estado e produz uma resposta tipada.
/// </summary>
/// <typeparam name="TResponse">Tipo retornado após a execução do comando.</typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse> { }
