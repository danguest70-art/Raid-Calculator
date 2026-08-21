namespace RaidCalculator;

public static class BuffHelper
{
    public static void UpdateBuff(Champion[] champions, Champion nextChampion, Skill skill)
    {
        DecrementBuffTurns(nextChampion);
        ApplyReadyBuff(champions, nextChampion, skill);
    }

    private static void ApplyReadyBuff(Champion[] champions, Champion caster, Skill skill)
    {
        skill.Buff?.ApplyBuff(champions, caster);
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
