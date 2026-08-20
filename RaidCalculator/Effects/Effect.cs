namespace RaidCalculator;

public abstract class Effect
{
    public int EffectCoolDown = 0;
    public int CurrentCoolDown = 0;
    public int Uses = 0;
    public int Priority = 0;

    public void ApplyEffect(Champion[] champions, Champion? caster = null)
    {
        if (CurrentCoolDown == 0)
        {
            var affectedChampions = AppliesTo(champions);
            ApplyEffectInternal(affectedChampions, caster);

            CurrentCoolDown = EffectCoolDown;
        }
    }
    
    public void ReduceCoolDown()
    {
        if (CurrentCoolDown >= 1)
        {
            CurrentCoolDown -= 1;
        }
    }

    public abstract void ApplyEffectInternal(Champion[] champions, Champion? caster = null);
    public abstract Champion[] AppliesTo(Champion[] champions);
}