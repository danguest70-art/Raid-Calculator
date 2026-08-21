namespace RaidCalculator.Effects;

public class AdvancedTurnMeterEffect : Effect
{
    public AdvancedTurnMeterEffect()
    {
        Name = "Ally Turn Meter Fill And Extra Turn";
    }

    public override void ConfigureEffectPipeline(EffectPipeline pipeline)
    {
        pipeline
            .Then(EffectSteps.FilterToAllies)
            .Then(p => EffectSteps.IncreaseTurnMeterForChampions(p, 15))
            .Split(
                left => left
                    .Then(EffectSteps.FilterToCaster)
                    .Then(EffectSteps.AddTurnToChampions),
                _ => { });
    }
}
