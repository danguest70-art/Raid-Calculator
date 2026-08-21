using RaidCalculator.Attack;
using RaidCalculator.Buffs;
using RaidCalculator.Effects;

namespace RaidCalculator;

public static class Skills
{
    public static Skill BoonOfSpeed() => new()
    {
        Name = "BOON OF SPEED",
        SkillCoolDown = 5,
        Priority = 3,
        Actions =
        [
            new BasicTurnMeterEffect(),
            new SpeedIncrease(),
            new BasicAttack()
        ]
    };

    public static Skill EmptySkill() => new()
    {
        Name = "Empty Skill",
        SkillCoolDown = 0,
        Priority = 0,
        Actions = [new BasicAttack()]
    };

    public static Skill SoothingChant() => new()
    {
        Name = "SOOTHING CHANT",
        SkillCoolDown = 3,
        Priority = 2,
        Actions =
        [
            new AoeTargetHealEffect(0.35),
            new BasicAttack()
        ]
    };
}
