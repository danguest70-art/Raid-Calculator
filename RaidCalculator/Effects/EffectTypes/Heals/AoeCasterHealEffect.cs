using RaidCalculator.Effects;

namespace RaidCalculator;

public class AoeCasterHealEffect : Effect
{
    public AoeCasterHealEffect()
    {
        Name = "Health Effect";
    }
    
    public override void ConfigureEffectPipeline(EffectPipeline pipeline)
    {
        pipeline
            .Then(EffectSteps.FilterToCaster)
            .Then(p => EffectSteps.IncreaseTurnMeterForChampions(p, 1.15));
    }
}