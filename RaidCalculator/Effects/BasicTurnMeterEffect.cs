using RaidCalculator.Effects;

namespace RaidCalculator;

public class BasicTurnMeterEffect : Effect
{
    public BasicTurnMeterEffect()
    {
        Name = "Green Sword";
        Priority = 2;
        EffectCoolDown = 5;
    }
    
    // This effect will increase all the allies Turn Meter by 15%
    public override void ConfigureEffectPipeline(EffectPipeline pipeline)
    {
        pipeline
            .Then(EffectSteps.FilterToAllies)
            .Then(p => EffectSteps.IncreaseTurnMeterForChampions(p, 15));
    }
}