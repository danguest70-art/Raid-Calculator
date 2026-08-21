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

        var affectedChampions = AppliesTo(champions);
        ApplyBuffInternal(affectedChampions, caster);
        CurrentCoolDown = BuffCoolDown;
    }

    public void ReduceCoolDown()
    {
        if (CurrentCoolDown > 0)
        {
            CurrentCoolDown--;
        }
    }

    public abstract void ApplyBuffInternal(Champion[] champions, Champion? caster = null);
    public abstract Champion[] AppliesTo(Champion[] champions);
}
