namespace Rewardly.Application.Responses;

public class ResponseBase<T>
{
    public ResponseBase(bool success, T? data, IReadOnlyCollection<string>? errors)
    {
        Success = success;
        Data = data;
        Errors = errors ?? Array.Empty<string>();
    }

    public bool Success { get; private set; }
    public T? Data { get; private set; }
    public IReadOnlyCollection<string> Errors { get; private set; }

    public static ResponseBase<T> Ok(T Data) 
        => new(true, Data, null);

    public static ResponseBase<T> Fail(params string[] Erros)
        => new(false, default, Erros);
}
