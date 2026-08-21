using RaidCalculator.Buffs;

namespace RaidCalculator;

public static class Skills
{
    public static Skill BoonOfSpeed = new()
    {
        Name = "BOON OF SPEED",
        SkillCoolDown = 5,
        Buff = new SpeedIncrease(),
        Effect = new BasicTurnMeterEffect(),
        Priority = 5
    };

    public static Skill EmptySkill = new()
    {
        Name = "Empty Skill",
        SkillCoolDown = 0,
        Priority = 0
    };
}