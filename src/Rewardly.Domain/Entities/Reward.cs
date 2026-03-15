using Rewardly.Domain.Enums;

namespace Rewardly.Domain.Entities;

public sealed class Reward
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int PointsCost { get; private set; }
    public RewardCategoryType CategoryType { get; private set; }
    public bool IsActive { get; private set; }

    public Reward(string name, string description, int pointsCost, RewardCategoryType categoryType)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        PointsCost = pointsCost;
        CategoryType = categoryType;
        IsActive = true;
    }

    public void Disable() 
        => IsActive = false;
}
