namespace RaidCalculator;

public class AdvancedTurnMeterEffect : Effect
{
    public AdvancedTurnMeterEffect()
    {
        Name = "Red Sword";
        Priority = 2;
        EffectCoolDown = 5;
    }

    // This effect will increase all the allies Turn Meter by 15%
    public override void ApplyEffectInternal(Champion[] champions, Champion? caster)
    {
        var allies = champions.Where(c => c.IsChampion);
        var enemies = champions.Where(c => !c.IsChampion);

        foreach (var ally in allies)
        {
            ally.TurnMeter += 15;
        }

        if (caster != null)
        {
            caster.ExtraTurns++;
        }
    }

    public override Champion[] AppliesTo(Champion[] champions)
    {
        return champions;
    }
}