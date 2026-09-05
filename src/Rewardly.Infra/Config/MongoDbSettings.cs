namespace Rewardly.Infra.Config;

public sealed class MongoDbSettings
{
    public const string SectionName = "MongoDbSettings";

    public string DatabaseName { get; init; } = string.Empty;
    public string CollectionName { get; init; } = string.Empty;
    public string ConnectionString { get; init; } = string.Empty;
}
