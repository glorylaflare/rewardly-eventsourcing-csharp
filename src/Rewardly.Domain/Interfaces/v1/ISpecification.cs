namespace Rewardly.Domain.Interfaces.v1;

/// <summary>
/// Representa uma especificação de negócio para validação de objetos de domínio.
/// </summary>
/// <typeparam name="T">Tipo de objeto avaliado pela especificação.</typeparam>
public interface ISpecification<T>
{
    /// <summary>
    /// Avalia se o item informado satisfaz os critérios definidos pela especificação.
    /// </summary>
    /// <param name="item">Instância a ser validada.</param>
    /// <returns><see langword="true"/> quando o item atende aos critérios; caso contrário, <see langword="false"/>.</returns>
    bool IsSatisfiedBy(T item);
}
