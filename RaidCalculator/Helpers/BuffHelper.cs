namespace RaidCalculator;

public static class BuffHelper
{
    public static void UpdateBuff(ActionContext context, Champion[] champions, Champion nextChampion, Skill skill)
    {
        DecrementBuffTurns(nextChampion);
        ApplyReadyBuff(context, champions, nextChampion, skill);
    }

    private static void ApplyReadyBuff(ActionContext context, Champion[] champions, Champion caster, Skill skill)
    {
        skill.Buff?.ApplyBuff(context, champions, caster);
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
