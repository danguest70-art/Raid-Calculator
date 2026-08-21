namespace RaidCalculator.Buffs;

public abstract class Buff
{
    public string Name;
    public int BuffDuration;
    public int BuffCoolDown;
    public int CurrentCoolDown;
    public int Priority;

    protected Buff(string name, int duration, int cooldown, int priority)
    {
        Name = name;
        BuffDuration = duration;
        BuffCoolDown = cooldown;
        Priority = priority;
    }

    public void ApplyBuff(Champion[] champions, Champion? caster = null)
    {
        if (CurrentCoolDown != 0)
        {
            return;
        }

        var pipeline = new BuffPipeline()
        {
            Champions = champions,
            Caster = caster
        };

        GetBuffPipeline(pipeline);

        pipeline.Run();

        CurrentCoolDown = BuffCoolDown;
    }

    public void ReduceCoolDown()
    {
        if (CurrentCoolDown > 0)
        {
            CurrentCoolDown--;
        }
    }

    public abstract void GetBuffPipeline(BuffPipeline buffPipeline);
}
