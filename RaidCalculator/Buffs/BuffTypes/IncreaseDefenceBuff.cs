namespace RaidCalculator.Buffs;

public class IncreaseDefenceBuff : Buff
{
    public double DefenceMultiplier;

    public IncreaseDefenceBuff(
        int duration = 3,
        double defenceMultiplier = 1.6)
        : base("Defence Buff", duration)
    {
        DefenceMultiplier = defenceMultiplier;
    }

    public override void ConfigureBuffPipeline(BuffPipeline buffPipeline)
    {
        buffPipeline
            .Then(BuffSteps.FilterToAllies)
            .Then(p => BuffSteps.ApplyDefenceMultiplierBuffToChampions(p, DefenceMultiplier, BuffDuration));
    }
}
