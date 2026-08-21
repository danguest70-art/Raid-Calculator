using RaidCalculator.Effects;

namespace RaidCalculator;

public abstract class Effect
{
    public string Name;

    public void ApplyEffect(ActionContext actionContext, Champion[] champions, Champion? caster = null)
    {
            var pipeline = new EffectPipeline
            {
                Champions = champions,
                Caster = caster,
                Context = actionContext,
            };

            ConfigureEffectPipeline(pipeline);

            pipeline.Run();
    }

    public abstract void ConfigureEffectPipeline(EffectPipeline pipeline);
}