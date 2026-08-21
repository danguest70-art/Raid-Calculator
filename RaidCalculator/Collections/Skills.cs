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
        Priority = 3
    };

    public static Skill EmptySkill = new()
    {
        Name = "Empty Skill",
        SkillCoolDown = 0,
        Priority = 0
    };

    public static Skill SoothingChant = new()
    {
        Name = "SOOTHING CHANT",
        SkillCoolDown = 3,
        Priority = 2,
        Effect = new AoeTargetHealEffect(1.35)
    };
}