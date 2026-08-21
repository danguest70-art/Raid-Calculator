namespace RaidCalculator.Effects;

public class AoeTargetHealEffect : Effect
{
    private readonly double _healMultiplier;

    public AoeTargetHealEffect(double healMultiplier)
    {
        Name = "Heal Lowest Ally";
        _healMultiplier = healMultiplier;
    }

    public override void ConfigureEffectPipeline(EffectPipeline pipeline)
    {
        pipeline
            .Then(EffectSteps.FilterToAllies)
            .Then(EffectSteps.FilterOutCaster)
            .Then(EffectSteps.FilterToLowestHealthChampion)
            .Then(p => EffectSteps.HealChampions(p, _healMultiplier));
    }
}
