namespace RaidCalculator;

public class Skill
{
    public required string Name { get; init; }
    public int SkillCoolDown { get; init; }
    public int CurrentCoolDown { get; set; }
    public int Priority { get; init; }
    public IReadOnlyList<ISkillAction> Actions { get; init; } = [];

    public Skill Clone() => new()
    {
        Name = Name,
        SkillCoolDown = SkillCoolDown,
        CurrentCoolDown = 0,
        Priority = Priority,
        Actions = [..Actions]
    };
}
