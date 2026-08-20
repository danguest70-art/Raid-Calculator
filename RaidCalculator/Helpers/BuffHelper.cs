namespace RaidCalculator;

public static class BuffHelper
{
    public static void UpdateBuff(Champion[] champions, Champion nextChampion)
    {
        DecrementBuffTurns(nextChampion);
        SetBuffs(champions, nextChampion);
        ReduceBuffCoolDown(nextChampion);
    }
    
    private static void SetBuffs(Champion[] champions, Champion caster)
    {
        var applicableBuffs = caster.Buffs.Where(e => e.CurrentCoolDown == 0).OrderByDescending(e => e.Priority).FirstOrDefault();

        if (applicableBuffs != null)
        {
            applicableBuffs.SetBuffs(champions, caster);
        }
    }
    
    private static void ReduceBuffCoolDown(Champion caster)
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

            if (appliedBuff.TurnsRemaining <= 0)
            {
                appliedBuff.Buff.RemoveBuff(champion);
                champion.ActiveBuffs.Remove(appliedBuff);
            }
        }
    }
}