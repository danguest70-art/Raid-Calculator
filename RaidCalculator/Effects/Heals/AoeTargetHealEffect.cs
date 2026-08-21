namespace RaidCalculator;

public class AoeTargetHealEffect : Effect
{
    public AoeTargetHealEffect()
    {
        Name = "Health Effect";
        Priority = 10;
        EffectCoolDown = 5;
    }
    
    // This effect will increase all the allies Turn Meter by 15%
    public override void ApplyEffectInternal(Champion[] champions, Champion? caster)
    {
        foreach (var champion in champions)
        {
            champion.Health = champion.MaxHp * 1.15;
        }
    }

    public override Champion[] AppliesTo(Champion[] champions)
    {
        return champions.Where(c => c.IsChampion).ToArray();
    }
}