namespace Rewardly.Infra.Config;

public sealed class MongoDbettings
{
    public string? DatabaseName { get; init; }
    public string? CollectionName { get; init; }
    public string? ConnectionString { get; init; }
}
