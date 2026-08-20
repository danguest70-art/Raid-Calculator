namespace RaidCalculator.Buffs;

public abstract class Buff
{
    public int BuffCoolDown = 0;
    public int CurrentCoolDown = 0;
    public int BuffDuration = 0;
    public string Name;
    public int Priority = 0;

    public void SetBuffs(Champion[] champions, Champion? caster = null)
    {
        if (CurrentCoolDown == 0)
        {
            var affectedChampions = AppliesTo(champions);
            SetBuffsInternal(affectedChampions, caster);

            CurrentCoolDown = BuffCoolDown;
        }
    }
    
    public void ReduceCoolDown()
    {
        if (CurrentCoolDown >= 1)
        {
            CurrentCoolDown -= 1;
        }
    }

    public abstract void SetBuffsInternal(Champion[] champions, Champion? caster = null);
    public abstract void RemoveBuff(Champion champion);
    public abstract Champion[] AppliesTo(Champion[] champions);
}