namespace RaidCalculator.Effects;

public class AoeCasterHealEffect : Effect
{
    private readonly double _healMultiplier;

    public AoeCasterHealEffect(double healMultiplier = 0.3)
    {
        Name = "Self Heal";
        _healMultiplier = healMultiplier;
    }

    public override void ConfigureEffectPipeline(EffectPipeline pipeline)
    {
        pipeline
            .Then(EffectSteps.FilterToCaster)
            .Then(p => EffectSteps.HealChampions(p, _healMultiplier));
    }
}
