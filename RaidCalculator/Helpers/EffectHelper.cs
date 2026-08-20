namespace RaidCalculator;

public static class EffectHelper
{
    public static void ApplyEffect(Champion[] champions, Champion nextChampion)
    {
        var usedEffect = ApplyEffects(champions, nextChampion);

        if (usedEffect != null)
        {
            Console.WriteLine($"Champion {nextChampion.Name} used effect: {usedEffect.Name}");
        }
        
        ReduceEffectCoolDowns(nextChampion);
    }
    
    private static Effect? ApplyEffects(Champion[] champions, Champion caster)
    {
        var applicableEffect = caster.Effects.Where(e => e.CurrentCoolDown == 0).OrderByDescending(e => e.Priority).FirstOrDefault();

        if (applicableEffect != null)
        {
            applicableEffect.ApplyEffect(champions, caster);
        }

        return applicableEffect;
    }

    private static void ReduceEffectCoolDowns(Champion caster)
    {
        foreach (var effect in caster.Effects)
        {
            effect.ReduceCoolDown();
        }
    }

}