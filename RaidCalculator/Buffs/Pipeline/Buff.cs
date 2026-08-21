namespace RaidCalculator.Buffs;

public abstract class Buff
{
    public string Name;
    public int BuffDuration;

    protected Buff(string name, int duration)
    {
        Name = name;
        BuffDuration = duration;
    }

    public void ApplyBuff(ActionContext actionContext, Champion[] champions, Champion? caster = null)
    {
        var pipeline = new BuffPipeline()
        {
            Champions = champions,
            Caster = caster,
            Context = actionContext,
            Buff = this
        };

        GetBuffPipeline(pipeline);

        pipeline.Run();
    }

    public abstract void GetBuffPipeline(BuffPipeline buffPipeline);
}
