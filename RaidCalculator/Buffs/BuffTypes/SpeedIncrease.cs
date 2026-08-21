namespace RaidCalculator.Buffs;

public class SpeedIncrease : Buff
{
    public double SpeedMultiplier;

    public SpeedIncrease(
        int duration = 2,
        double speedMultiplier = 1.3)
        : base("Speed Increase", duration)
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
