namespace RaidCalculator;

public static class BuffHelper
{
    public static void UpdateBuff(Champion[] champions, Champion nextChampion)
    {
        DecrementBuffTurns(nextChampion);
        ApplyReadyBuff(champions, nextChampion);
        ReduceBuffCoolDowns(nextChampion);
    }

    private static void ApplyReadyBuff(Champion[] champions, Champion caster)
    {
        var buff = caster.Buffs
            .Where(b => b.CurrentCoolDown == 0)
            .OrderByDescending(b => b.Priority)
            .FirstOrDefault();

        buff?.ApplyBuff(champions, caster);
    }

    private static void ReduceBuffCoolDowns(Champion caster)
    {
        foreach (var buff in caster.Buffs)
        {
            buff.ReduceCoolDown();
        }
    }

    private static void DecrementBuffTurns(Champion champion)
    {
        foreach (var appliedBuff in champion.ActiveBuffs.ToList())
        {
            appliedBuff.TurnsRemaining--;

            if (appliedBuff.TurnsRemaining > 0)
            {
                continue;
            }

            champion.ActiveBuffs.Remove(appliedBuff);
        }
    }
}
