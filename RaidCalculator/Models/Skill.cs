using RaidCalculator.Buffs;

namespace RaidCalculator;

public class Skill
{
    public string Name;
    public Effect? Effect;
    public Buff? Buff;
    public int SkillCoolDown;
    public int CurrentCoolDown = 0;
    public int Priority;
}