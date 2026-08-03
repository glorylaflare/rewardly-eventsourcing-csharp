namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// Define o contrato para invocação dinâmica de comandos no pipeline de aplicação.
/// </summary>
public interface ICommandInvoker
{
    /// <summary>
    /// Executa o comando informado e retorna o resultado produzido pelo manipulador.
    /// </summary>
    /// <param name="command">Comando a ser invocado no fluxo de processamento.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Resultado da execução do comando, quando houver retorno associado.</returns>
    Task<object?> InvokeAsync(ICommandBase command, CancellationToken cancellationToken);
}
