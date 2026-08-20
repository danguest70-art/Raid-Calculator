namespace RaidCalculator;

public class NewTurnMeterEffect : Effect
{

    public NewTurnMeterEffect()
    {
        Name = Name = "Blue Sword";
        Priority = 0;
        EffectCoolDown = 3;
    }
    
    // This effect will increase the casters Turn Meter by 15%, it will also
    // increase the ally with the highest turn Meter by 15%
    public override void ApplyEffectInternal(Champion[] champions, Champion? caster)
    {
        caster.TurnMeter += 15;

        var championWithHighestTurnMeter =  champions.Where(c => c.Name != caster.Name).OrderBy(c => c.TurnMeter).FirstOrDefault();

        if (championWithHighestTurnMeter != null)
        {
            championWithHighestTurnMeter.TurnMeter += 15;
        }
    }

    public override Champion[] AppliesTo(Champion[] champions)
    {
        return champions.Where(c => c.IsChampion).ToArray();
    }
}