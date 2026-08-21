namespace RaidCalculator.Effects;

public abstract class Effect : ISkillAction
{
    public string Name { get; set; } = "";

    public void Execute(ActionContext context, Champion[] champions, Champion caster)
    {
        ApplyEffect(context, champions, caster);
    }

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
