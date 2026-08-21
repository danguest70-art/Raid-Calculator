namespace RaidCalculator.Buffs;

public abstract class Buff : ISkillAction
{
    public string Name { get; }
    public int BuffDuration { get; }

    protected Buff(string name, int duration)
    {
        Name = name;
        BuffDuration = duration;
    }

    public void Execute(ActionContext context, Champion[] champions, Champion caster)
    {
        ApplyBuff(context, champions, caster);
    }

    public void ApplyBuff(ActionContext actionContext, Champion[] champions, Champion? caster = null)
    {
        var pipeline = new BuffPipeline
        {
            Champions = champions,
            Caster = caster,
            Context = actionContext,
            Buff = this
        };

        ConfigureBuffPipeline(pipeline);
        pipeline.Run();
    }

    public abstract void ConfigureBuffPipeline(BuffPipeline buffPipeline);
}
