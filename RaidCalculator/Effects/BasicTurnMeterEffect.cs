namespace RaidCalculator;

public class BasicTurnMeterEffect : Effect
{
    public BasicTurnMeterEffect()
    {
        Name = "Green Sword";
        Priority = 2;
        EffectCoolDown = 3;
    }
    
    // This effect will increase all the allies Turn Meter by 15%
    public override void ApplyEffectInternal(Champion[] champions, Champion? caster)
    {
        foreach (var champion in champions)
        {
            champion.TurnMeter += 15;
        }
    }

    public override Champion[] AppliesTo(Champion[] champions)
    {
        return champions.Where(c => c.IsChampion).ToArray();
    }
}