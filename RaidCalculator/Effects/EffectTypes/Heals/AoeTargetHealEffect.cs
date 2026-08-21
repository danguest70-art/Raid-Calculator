using RaidCalculator.Effects;

namespace RaidCalculator;

public class AoeTargetHealEffect : Effect
{
    private double HealMultiplier;
    
    public AoeTargetHealEffect(double healMultiplier)
    {
        Name = "Health Effect";
        HealMultiplier = healMultiplier;
    }
    
    public override void ConfigureEffectPipeline(EffectPipeline pipeline)
    {
        pipeline
            .Then(EffectSteps.FilterToAllies)
            .Then(EffectSteps.FilterOutCaster)
            .Then(EffectSteps.FilterToLowestHealthChampion)
            .Then(p => EffectSteps.HealChampions(p, HealMultiplier));
    }
}