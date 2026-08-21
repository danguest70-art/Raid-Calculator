namespace RaidCalculator.Buffs;

public class IncreaseDefenceBuff : Buff
{
    public double DefenceMultiplier;

    public IncreaseDefenceBuff(
        int duration = 3,
        int cooldown = 4,
        int priority = 4,
        double defenceMultiplier = 1.6)
        : base("Defence Buff", duration, cooldown, priority)
    {
        DefenceMultiplier = defenceMultiplier;
    }

    public override void GetBuffPipeline(BuffPipeline buffPipeline)
    {
        buffPipeline
            .Then(BuffSteps.FilterToAllies)
            .Then(p => BuffSteps.ApplyDefenceMultiplierBuffToChampions(p, DefenceMultiplier, BuffDuration));
    }
}