namespace RaidCalculator.Buffs;

public class SpeedIncrease : Buff
{
    public double SpeedMultiplier;

    public SpeedIncrease(
        int duration = 2,
        int cooldown = 5,
        int priority = 4,
        double speedMultiplier = 1.3)
        : base("Speed Increase", duration, cooldown, priority)
    {
        SpeedMultiplier = speedMultiplier;
    }

    public override void GetBuffPipeline(BuffPipeline buffPipeline)
    {
        buffPipeline
            .Then(BuffSteps.FilterToAllies)
            .Then(p => BuffSteps.ApplySpeedMultiplierBuffToChampions(p, SpeedMultiplier, BuffDuration));
    }
}
