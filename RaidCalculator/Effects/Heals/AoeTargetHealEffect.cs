using RaidCalculator.Effects;

namespace RaidCalculator;

public class AoeTargetHealEffect : Effect
{
    public AoeTargetHealEffect()
    {
        Name = "Health Effect";
        Priority = 10;
        EffectCoolDown = 5;
    }
    
    public override void ConfigureEffectPipeline(EffectPipeline pipeline)
    {
        pipeline
            .Then(EffectSteps.FilterToAllies)
            .Then(p => EffectSteps.IncreaseTurnMeterForChampions(p, 1.15));
    }
}