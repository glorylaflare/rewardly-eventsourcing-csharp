namespace Rewardly.Application.Responses;

public class ResponseBase<T>
{
    public bool Success { get; private set; }
    public T? Data { get; private set; }
    public IReadOnlyCollection<string> Errors { get; private set; }

    public ResponseBase(bool success, T? data, IReadOnlyCollection<string>? errors)
    {
        Success = success;
        Data = data;
        Errors = errors ?? Array.Empty<string>();
    }

    public static ResponseBase<T> Ok(T data) 
        => new(true, data, null);

    public static ResponseBase<T> Fail(params string[] erros)
        => new(false, default, erros);
}
